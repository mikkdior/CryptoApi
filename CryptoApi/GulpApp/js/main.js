jQuery(function ($) {
    //--------------------------------------
    // UI
    (function () {
        $('input[type="checkbox"], input[type="radio"]').checkboxradio();
        //$('input[data-type="date"]').datepicker({
        //    firstDay: 1
        //});

        //$('select').selectmenu({
        //    change: function () {
        //        $(this).change();
        //    }
        //});

        //$('.dcj-slider-range').slider({
        //    range: true,
        //    min: 0,
        //    max: 500,
        //    values: [0, 500]
        //});

        //$('.dcj-resizable').dcLink('resizable', {
        //    create: function (e, ui) {
        //        var $this = $(this);
        //        var handles = $this.resizable('option', 'handles');
        //        handles = handles.split(',');

        //        for (var i in handles) {
        //            if (!handles[i]) return;

        //            var class_name = `ui-resizable-has-${handles[i].trim()}`;
        //            $this.addClass(class_name);
        //        }
        //    }
        //});

        //$('.dcj-scroll').jScrollPane({
        //    autoReinitialise: true,
        //    mouseWheelSpeed: 100
        //});

        //$('.dcj-autosize').each(function () { autosize(this); });
        //$('.dcj-autosize').on('keyup change', function () {
        //    autosize(this);
        //});

        //$('.dcj-hiding-panel').dcLink('dcHidingPanel');

        //$.dc.actions.doAction('translate_app');
    })();
    // /UI
    //--------------------------------------
    // TEMPLATE
    //(function () {
    //    var $main = $('.dc-main');
    //    if (!$main.length) return;

    //})();
    // /TEMPLATE
    //--------------------------------------
    // Test
    // (function () {
    //
    // })();
    // /Test
    //--------------------------------------
    // onReady
    // (function () {
    //     $.dc.onReady = function (Callback) {
    //         $.dc.onReady.dc = {};
    //         var Static = $.dc.onReady.dc;
    //         Static.callbacks = Static.callbacks || [];
    //
    //         function init () {
    //             addCallback();
    //             if (Static.ready) {
    //                 doCallbacks();
    //                 return;
    //             }
    //
    //             if (Static.inited) return;
    //             Static.inited = true;
    //
    //             $(document).dcTl('json/tl.json');
    //             setEvents();
    //         }
    //
    //         function setEvents () {
    //             $.dc.actions.onReady(function () {
    //                 Static.actions_ready = true;
    //                 check();
    //             });
    //
    //             $.dc.f.tlOnReady(function () {
    //                 Static.tl_ready = true;
    //                 check();
    //             });
    //         }
    //
    //         function addCallback () {
    //             Static.callbacks.push(Callback);
    //         }
    //
    //         function doCallbacks () {
    //             while(Static.callbacks.length) {
    //                 var func = Static.callbacks.pop();
    //                 func();
    //             }
    //         }
    //
    //         function check () {
    //             if (Static.actions_ready && Static.tl_ready)
    //                 doCallbacks();
    //         }
    //
    //         init();
    //     }
    // })();
    // /onReady
    //--------------------------------------
});
