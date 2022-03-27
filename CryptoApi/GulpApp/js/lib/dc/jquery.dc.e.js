(function ($) {
    var E = $.dc.e;
    var D = $.dc.d;

    // Событие смены media-экрана по bootstrap.
    (function () {
        E.on_media_change = 'dc_media';
        E.on_media_mobile = '';
        E.on_media_desktop = '';
        var now_media = '';

        $.each(D.bs_breakpoints, function (Key, Item) {
            E['on_media_change_' + Key] = E.on_media_change + '_' + Key;

            if (Item <= D.mobile_max_width) {
                E.on_media_mobile += ' ' + E['on_media_change_' + Key];
            } else {
                E.on_media_desktop += ' ' + E['on_media_change_' + Key];
            }
        });

        E.on_media_mobile = E.on_media_mobile.trim();
        E.on_media_desktop = E.on_media_desktop.trim();

        $.each(D.bs_breakpoints, function (Key, Item) {
            $('*').on(E['on_media_change_' + Key], '*', function (e) {
                e.stopPropagation();
            });
        });

        $('*').on(E.on_media_change, '*', function (e) {
            e.stopPropagation();
        });

        function check () {
            var width = $(window).width();
            var result_key = '';
            var result_width = 0;

            $.each(D.bs_breakpoints, function (Key, Item) {
                if (width >= Item && Item >= result_width) {
                    result_width = Item;
                    result_key = Key;
                }
            });

            if (now_media != result_key) {
                now_media = result_key;

                $(function () {
                    $('*').trigger(E.on_media_change, { key: now_media });
                    $('*').trigger(E['on_media_change_' + now_media], { key: now_media });
                });
            }
        }
        check();

        $(window).resize(function () {
            check();
        });
    })();
})(jQuery);
