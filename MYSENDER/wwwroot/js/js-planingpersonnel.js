$(document).ready(function () {
    $("#CalendarPlaning").click(function () {

        location.href = $("#planing").data("url-list-personnel");

    });

    /* initialize the external events
         -----------------------------------------------------------------*/
    var event = $("#planing").data("model");
    event.forEach(function (e) {
        e.start = moment(e.start, "DD/MM/YYYY hh:mm").format("YYYY-MM-DD hh:mm");
        e.end = moment(e.end, "DD/MM/YYYY hh:mm").format("YYYY-MM-DD hh:mm");
        e.end = moment(e.end).add(1, 'days'); // pour afficher les date de fin inclusive.
    });
    /* initialize the calendar
    -----------------------------------------------------------------*/
    var cal = $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        editable: true,
        droppable: true,
        events: event
    });

});