$(document).ready(function() {

    $('#calendar').fullCalendar({
        locale: "fr",
        header: {
            left: "today prev,next title",
            right: ""
        },
        eventLimit: 3,
        eventLimitText: "supplémentaires",
        dayOfWeekPopoverFormat: "ddd",
        dayPopoverFormat: "D",
        dayRender: function(date, cell) {
            if (cell.hasClass("fc-today")) {
                var index = cell.index();
                var header = $("#calendar thead.fc-head th").eq(index);
                header.addClass("fc-today");

                var weeks = $("#calendar tbody.fc-body .fc-week");
                if (weeks.length === 0) return;

                var week = weeks[0];
                var hasToday = $(week).find(".fc-today");
                if (hasToday.length > 0) header.addClass("fc-today-now");
            }
        },
        events: events,
        viewRender: function(view, element) {
            //$("#mysender-calendar > ul").remove();
        },
        eventRender: function (event, element, view) {
            var title = event.title;

            var tooltip = event.trainingLabel;
            tooltip += "<br><span class='glyphicon glyphicon-arrow-right'></span>" + event.moduleLabel;
            tooltip += "<hr>" + event.structureName;

            if (event.convocationSent) {
                title = "<span class='glyphicon glyphicon-check text-success'></span>" + title;
                tooltip += "<br><span class='text-success'><span class='glyphicon glyphicon-check'></span>Convocations envoyées</span>";
            }

            if (event.missingLocation) {
                title = "<span class='glyphicon glyphicon-map-marker text-danger'></span>" + title;
                tooltip += "<br><span class='text-danger'><span class='glyphicon glyphicon-map-marker'></span>Lieu non défini</span>";
            }

            if (event.missingTrainer) {
                title = "<span class='glyphicon glyphicon-user text-danger'></span>" + title;
                tooltip += "<br><span class='text-danger'><span class='glyphicon glyphicon-user'></span>Formateur non défini</span>";
            }

            if (event.status === "P") {
                element.addClass("fc-event-planned");
            }

            if (event.status === "O") {
                element.addClass("fc-event-open");
            }

            if (event.nbAttendees >= event.nbMinAttendees) {
                element.addClass("fc-event-ready");
            }

            if (moment(event.end).isBefore(moment())) {
                element.addClass("fc-event-done");
            }

            element.find('.fc-title').html(title);
            element.attr('data-id', event.sessionId);

            //tooltip += "<br>" + event.statusLabel;
            tooltip += "<br>Inscrits : " + event.nbAttendees + "/" + event.nbMaxAttendees + " (min: " + event.nbMinAttendees + ")";

            element.attr('title', "<div class='fc-event-tooltip'>" + tooltip + "</div>");
            element.tooltip({
                container: "body",
                placement: "top",
                html: true
            });
        },
        dayClick: function (date, jsEvent, view) {
            $("#mysender-calendar > ul").remove();
        },
        eventClick: function (event, jsEvent, view) {
            $("#mysender-calendar > ul").remove();
            var moduleMenu = $("#dropdown-module-" + event.moduleId + " + ul").clone();
            var sessionMenu = $("#dropdown-" + event.sessionId + " + ul").clone();
            $(moduleMenu)
                .css("display", "block")
                .prepend($("<li>").attr("role", "separator").addClass("divider"))
                .prepend($("<li>").addClass("dropdown-submenu").append($("<a>").append("Session")).append(sessionMenu));
            var parent = $(this).parents(".col-lg-10");
            $(moduleMenu).css("top", ($(this).offset().top - $(parent).offset().top) + 22);
            $(moduleMenu).css("left", $(this).offset().left - $(parent).offset().left);
            $(this).parents("#mysender-calendar").append(moduleMenu);
        },
        eventMouseover: function (event, jsEvent, view) {
            $('a.fc-event[data-id="' + event.sessionId + '"]').addClass("fc-event-highlight");
        },
        eventMouseout: function (event, jsEvent, view) {
            $('a.fc-event[data-id="' + event.sessionId + '"]').removeClass("fc-event-highlight");
        }
    });
    $("#mysender-calendar").on("mouseleave", "> ul", function () {
        $(this).remove();
    });
});