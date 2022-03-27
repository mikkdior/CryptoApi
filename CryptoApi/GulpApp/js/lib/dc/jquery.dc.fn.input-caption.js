(function ($) {
    $.fn.dcInputCaption = function (Attr) {
        var Self = this;

        if (typeof Attr !== 'string') {
            var Conf = {
                Class: 'dcj-input-caption',
                WrapperCss: 'body',
                Top: 0,
                Left: 0,
                Right: false,
                Bottom: false,
                Text: ''
            };

            $.extend(Conf, Attr);
        }

        return this.each(function () {
            // PRIVATE FIELDS
            var Item = this;

            if (Item.dc === undefined) {
                Item.dc = {};
            }

            var Dc = Item.dc;
            var $Item;

            var CaptionHtml = '<div />';

            var CaptionStyles = {
                position: 'absolute',
                display: 'none',
                'z-index': 1
            };
            // /PRIVATE FIELDS
            //--------------------------------------------
            // PUBLIC FIELDS
            Dc.Showed = false;
            //...................................
            // /PUBLIC FIELDS
            //--------------------------------------------
            // INIT
            function init () {
                setVars();
                setEvents();
                choiceAction();
            }
            //...................................
            function setVars () {
                if (Dc.conf === undefined)
                    Dc.conf = Conf;

                $Item = $(Item);
            }
            //...................................
            function setEvents () {}
            //...................................
            function choiceAction () {
                if (typeof Attr === 'string') {
                    if (typeof Dc[Attr] === 'function')
                        Dc[Attr]();
                } else {
                    Dc.default();
                }
            }
            //...................................
            // /INIT
            //--------------------------------------------
            // PUBLIC
            Dc.default = function () {
                create();
            };
            //...................................
            Dc.show = function () {
                setPosition();
                Dc.$caption.show();
                Dc.Showed = true;
            };
            //...................................
            Dc.hide = function () {
                Dc.$caption.hide();
                Dc.Showed = false;
            };
            //...................................
            // /PUBLIC
            //--------------------------------------------
            // EVENTS
            //...................................
            // /EVENTS
            //--------------------------------------------
            // PRIVATE
            function doUserEvent (Name, Data) {
                if (typeof(Conf[Name]) == 'function') return Conf[Name](Data);
            }
            //...................................
            function create () {
                Dc.$caption = $(CaptionHtml);
                Dc.$caption.css(CaptionStyles);
                Dc.$caption.html(Conf.Text);

                if (Conf.Class)
                    Dc.$caption.addClass(Conf.Class);

                $('body').append(Dc.$caption);
            }
            //...................................
            function setPosition () {
                var item_top = $Item.offset().top;
                var item_left = $Item.offset().left;
                var item_width = $Item.width();
                var item_height = $Item.height();
                var top = 0;
                var left = 0;

                if (Dc.conf.Right === false) {
                    left = item_left + Dc.conf.Left;
                } else {
                    left = item_left + item_width - Dc.conf.Right;
                }

                if (Dc.conf.Bottom === false) {
                    top = item_top + Dc.conf.Top;
                } else {
                    top = item_top + item_height - Dc.conf.Bottom;
                }

                Dc.$caption.css({
                    top: top,
                    left: left
                });
            }
            //...................................
            // /PRIVATE
            //--------------------------------------------
            // PROPERTIES
            /*
            Object.defineProperty(Dc, 'ItemTop', {
                set: function (Value) {
                    _Test = Value;
                },

                get: function () {
                    return $Item.offset().top;
                }
            });
            */
            //...................................
            // /PROPERTIES
            //--------------------------------------------
            init();
            //--------------------------------------------
        });
    };
})(jQuery);
