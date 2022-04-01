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

// about-small
jQuery('.dc-about-small').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /about-small
//--------------------------------------------

// advantage
jQuery('.dc-advantage').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /advantage
//--------------------------------------------

// advantages
jQuery('.dc-advantages').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /advantages
//--------------------------------------------

// auth
jQuery('.dc-auth').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /auth
//--------------------------------------------

// breadcrumbs
jQuery('.dc-breadcrumbs').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /breadcrumbs
//--------------------------------------------

// coin
jQuery('.dc-coin').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /coin
//--------------------------------------------

// coin-info
jQuery('.dc-coin-info').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /coin-info
//--------------------------------------------

// coin-pair
jQuery('.dc-coin-pair').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /coin-pair
//--------------------------------------------

// coin-pair-info
jQuery('.dc-coin-pair-info').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /coin-pair-info
//--------------------------------------------

// coin-pairs
jQuery('.dc-coin-pairs').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /coin-pairs
//--------------------------------------------

// coins
jQuery('.dc-coins').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /coins
//--------------------------------------------

// coin-widget
jQuery('.dc-coin-widget').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /coin-widget
//--------------------------------------------

// contacts
jQuery('.dc-contacts').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /contacts
//--------------------------------------------

// copyright
jQuery('.dc-copyright').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /copyright
//--------------------------------------------

// desc
jQuery('.dc-desc').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /desc
//--------------------------------------------

// exchange-widget
jQuery('.dc-exchange-widget').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /exchange-widget
//--------------------------------------------

// faq
jQuery('.dc-faq').dcTpl(function ($, Export) {
   var $self = $(this);
});

//faq hide/open answers
document.querySelectorAll('.dc-faq').forEach((faq) => {
    document.querySelectorAll('.dc-section-text-block').forEach((main) => {
        
        function isAnswerOpened(answer) {
            return answer.style.display != 'none';
        }
        function toggle(main) {
            let answer = main.parentNode.querySelector('.dc-section-text-block__content');
            let toggle_view = main.querySelector('.dcg-btn .dcg-toggle_view');
            let toggle_hide = main.querySelector('.dcg-btn .dcg-toggle_hide');

            answer.style.display = isAnswerOpened(answer) ? 'none' : 'block';
            toggle_view.style.display = isAnswerOpened(answer) ? 'none' : 'inline-block';
            toggle_hide.style.display = isAnswerOpened(answer) ? 'inline-block' : 'none';
        }
        main.addEventListener('click', function (e) {
            toggle(main);
        })
    });
});


// /faq
//--------------------------------------------

// footer
jQuery('.dc-footer').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /footer
//--------------------------------------------

// guide
jQuery('.dc-guide').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /guide
//--------------------------------------------

// guide-list
jQuery('.dc-guide-list').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /guide-list
//--------------------------------------------

// head
jQuery('.dc-head').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /head
//--------------------------------------------

// head-advantages
jQuery('.dc-head-advantages').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /head-advantages
//--------------------------------------------

// header
jQuery('.dc-header').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /header
//--------------------------------------------

// layout
jQuery('.dc-layout').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /layout
//--------------------------------------------

// logo
jQuery('.dc-logo').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /logo
//--------------------------------------------

// main-menu
jQuery('.dc-main-menu').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /main-menu
//--------------------------------------------

// market-update
jQuery('.dc-market-update').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /market-update
//--------------------------------------------

// news-list
jQuery('.dc-news-list').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /news-list
//--------------------------------------------

// news-sketch
jQuery('.dc-news-sketch').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /news-sketch
//--------------------------------------------

// page-head-coins
jQuery('.dc-page-head-coins').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /page-head-coins
//--------------------------------------------

// page-head-main
jQuery('.dc-page-head-main').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /page-head-main
//--------------------------------------------

// page-head-pair
jQuery('.dc-page-head-pair').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /page-head-pair
//--------------------------------------------

// page-head-pairs
jQuery('.dc-page-head-pairs').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /page-head-pairs
//--------------------------------------------

// pagination
jQuery('.dc-pagination').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /pagination
//--------------------------------------------

// partners
jQuery('.dc-partners').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /partners
//--------------------------------------------

// section-text-block
jQuery('.dc-section-text-block').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /section-text-block
//--------------------------------------------

// section-text-blocks
jQuery('.dc-section-text-blocks').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /section-text-blocks
//--------------------------------------------

// service
jQuery('.dc-service').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /service
//--------------------------------------------

// services
jQuery('.dc-services').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /services
//--------------------------------------------

// soc-icons
jQuery('.dc-soc-icons').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /soc-icons
//--------------------------------------------

// subheader-coin
jQuery('.dc-subheader-coin').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /subheader-coin
//--------------------------------------------

// subheader-main
jQuery('.dc-subheader-main').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /subheader-main
//--------------------------------------------

// table
jQuery('.dc-table').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /table
//--------------------------------------------

// text-block
jQuery('.dc-text-block').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /text-block
//--------------------------------------------

// text-blocks
jQuery('.dc-text-blocks').dcTpl(function ($, Export) {
   var $self = $(this);
});
// /text-blocks
//--------------------------------------------
