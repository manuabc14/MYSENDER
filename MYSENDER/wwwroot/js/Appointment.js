$('#modal-calendar-container').on('loaded.bs.modal',
    function () {
        $(".input-time-start").bootstrapMaterialDatePicker({
            format: "DD/MM/YYYY HH:mm",
            lang: "fr",
            weekStart: 1,
            cancelText: "ANNULER",
            shortTime: true,
            switchOnClick: true
        }).on("change",
            function (e, date) {
                var starts = $("input[class='input-time-start filled valid']");
                var ends = $("input[class='input-time-end filled valid']");
                var el = $(this);
                var idx = starts.index(el);

                ends.each(function (index) {
                    if (index !== idx) return;
                    var end = moment(date).set({ h: 17, m: 00 });
                    if ($(this).val() !== "") {
                        var time = moment($(this).val(), "DD/MM/YYYY HH:mm");
                        end = moment(date).set({ h: time.hour(), m: time.minute() });
                    }
                    $(this).val(end.format("DD/MM/YYYY HH:mm"));
                });
            });

        $(".input-time-end").bootstrapMaterialDatePicker({
            format: "DD/MM/YYYY HH:mm",
            lang: "fr",
            date: false,
            weekStart: 1,
            cancelText: "ANNULER",
            shortTime: true,
            switchOnClick: true
        });

        $('form.material').materialForm();

        $('form').validate({
            errorPlacement: function (error, element) { }
        }); 

    });
