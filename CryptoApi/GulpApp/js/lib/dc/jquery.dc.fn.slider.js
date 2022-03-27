jQuery.fn.dcSlider = function (UserConf) {
    var $ = jQuery;
    var Self = this;

    var Conf = {
        SlidesCss: '.dcj-slide',
        SlideFaceCss: '.dcj-face',
        StartZIndex: '50',
        ActiveZIndex: '90',
        AnimationTime: 500,
        ActiveHeight: 429,

        onBeforeChange: function (Data) {},
        onAfterChange: function (Data) {},
        onChange: function (Data) {}
    };

    $.extend(Conf, UserConf);

    return this.each(function () {
        // PRIVATE FIELDS
        var Item = this;
        Item.dc = {};
        var Dc = Item.dc;
        var $Item = $(Item);

        var _Index;

        var _Drag = {
            Item: false,
            StartPos: 0,
            StartItemPos: 0
        };
        // /PRIVATE FIELDS
        //--------------------------------------------
        // PUBLIC FIELDS
        // /PUBLIC FIELDS
        //--------------------------------------------
        // INIT
        function init () {
            setVars();
            setEvents();

            Dc.refresh();
            Dc.setIndex(0);
        }
        //...................................
        function setVars () {
            Dc.$Slides.each(function (I) {
                this.Dc = (this.Dc) ? this.Dc : {};
                this.Dc.Index = I;
            });
        }
        //...................................
        function setEvents () {
            Dc.$Slides.on('touchstart', onDragStart);
            Dc.$Slides.on('touchmove', onDrag);
            Dc.$Slides.on('touchend', onDragEnd);
        }
        //...................................
        // /INIT
        //--------------------------------------------
        // PUBLIC
        Dc.next = function () {
            Dc.setIndex(Dc.Index - 1);
        };
        //...................................
        Dc.prev = function () {
            Dc.setIndex(Dc.Index + 1);
        };
        //...................................
        Dc.setIndex = function (Index) {
            if (isActive(Index)) return;

            if (Index >= Dc.$Slides.length || Index < 0) {
                Dc.ActiveSlide.animate(Dc.ActiveStyles, Conf.AnimationTime);

                return;
            }

            var old_index = Dc.Index;

            doUserEvent('onBeforeChange', {old: getSlide(old_index), new: getSlide(Index)});

            var slide = getSlide(Index);
            hideFace.call(slide);
            showFace.call(Dc.ActiveSlide);

            slide.animate(Dc.ActiveStyles, Conf.AnimationTime, function () {
                doUserEvent('onAfterChange', {old: getSlide(old_index), new: getSlide(Index)});
                doUserEvent('onChange', {old: getSlide(old_index), new: getSlide(Index)});
            });

            if (isRight(Index)) {
                Dc.ActiveSlide.animate(Dc.NextStyles, Conf.AnimationTime);
            } else {
                Dc.ActiveSlide.animate(Dc.PrevStyles, Conf.AnimationTime);
            }

            Dc.Index = Index;

            Dc.refresh();
        };
        //...................................
        Dc.refresh = function () {
            refreshSlidesPosition();
            refreshSlidesZIndex();
        };
        //...................................
        Dc.isFirstIndex = function (Index) {
            Index = (Index !== undefined) ? Index : Dc.Index;

            if (Index === 0) return true;
            return false;
        };
        //...................................
        Dc.isLastIndex = function (Index) {
            Index = (Index !== undefined) ? Index : Dc.Index;

            if (Index === (Dc.$Slides.length - 1)) return true;
            return false;
        }
        //...................................
        // /PUBLIC
        //--------------------------------------------
        // EVENTS
        function onDragStart (E) {
            var $this = $(this);

            _Drag = {
                Item: $this,
                StartPos: E.changedTouches[0].pageX,
                StartItemPos: $this.position().left
            }
        }
        //...................................
        function onDrag (E) {
            if (_Drag.Item === false) return;

            var x = E.changedTouches[0].pageX;
            var left = _Drag.StartItemPos - (_Drag.StartPos - x);
            _Drag.Item.css({ left: left });
        }
        //...................................
        function onDragEnd (E) {
            var old_x = _Drag.StartPos;
            var x = E.changedTouches[0].pageX;

            _Drag = {
                Item: false,
                StartPos: 0,
                StartItemPos: 0
            }

            if (x > old_x) onDragRight();
            if (x < old_x) onDragLeft();
        }
        //...................................
        function onDragRight () {
            Dc.prev();
        }
        //...................................
        function onDragLeft () {
            Dc.next();
        }
        //...................................
        // /EVENTS
        //--------------------------------------------
        // PRIVATE
        function doUserEvent (Name, Data) {
            if (typeof(Conf[Name]) == 'function')
                return Conf[Name].call($Item, Data);
        }
        //...................................
        function refreshSlidesZIndex () {
            var index = parseInt(Conf.StartZIndex) + parseInt(Ss.NextSlides.length);

            $.each(Dc.NextSlides, function () {
                this.css('z-index', --index);
            });

            index = Conf.StartZIndex;

            $.each(Dc.PrevSlides, function () {
                this.css('z-index', index++);
            });
        }
        //...................................
        function refreshSlidesPosition () {
            $.each(Dc.PrevSlides, function () {
                this.css(Ss.PrevStyles);
            });

            $.each(Dc.NextSlides, function () {
                this.css(Dc.NextStyles);
            });
        }
        //...................................
        function showFace (Time) {
            Time = (Time) ? Time : Conf.AnimationTime;

            this.find(Conf.SlideFaceCss).fadeIn(Time);
        }
        //...................................
        function hideFace (Time) {
            Time = (Time) ? Time : Conf.AnimationTime;

            this.find(Conf.SlideFaceCss).fadeOut(Time);
        }
        //...................................
        function isLeft (Index) {
            if (Index > Dc.Index) return true;

            return false;
        }
        //...................................
        function isRight (Index) {
            if (Index < Dc.Index) return true;

            return false;
        }
        //...................................
        function isActive (Index) {
            if (Index === Dc.Index) return true;

            return false;
        }
        //...................................
        function getSlide (Index) {
            return $(Dc.$Slides[Index]);
        }
        //...................................
        // /PRIVATE
        //--------------------------------------------
        // PROPERTIES
        Object.defineProperty(Dc, '$Slides', {
            get: function () {
                return $Item.find(Conf.SlidesCss);
            }
        });
        //...................................
        Object.defineProperty(Dc, 'PrevSlides', {
            get: function () {
                var slides = [];

                Dc.$Slides.each(function (I) {
                    if (I < Dc.Index) slides.push($(this));
                });

                return slides;
            }
        });
        //...................................
        Object.defineProperty(Dc, 'NextSlides', {
            get: function () {
                var slides = [];

                Ss.$Slides.each(function (I) {
                    if (I > Ss.Index) slides.push($(this));
                });

                return slides;
            }
        });
        //...................................
        Object.defineProperty(Dc, 'ActiveSlide', {
            get: function () {
                return getSlide(Dc.Index);
            }
        });
        //...................................
        Object.defineProperty(Dc, 'ActiveStyles', {
            get: function () {
                return {
                    height: Conf.ActiveHeight,
                    left: Dc.Width / 2 - Dc.$Slides.width() / 2,
                    top: (Dc.Height - Conf.ActiveHeight) / 2
                };
            }
        });
        //...................................
        Object.defineProperty(Dc, 'PrevStyles', {
            get: function () {
                return {
                    height: Dc.NormalSlideHeight,
                    left: Dc.Width - Dc.$Slides.width(),
                    top: 0
                };
            }
        });
        //...................................
        Object.defineProperty(Dc, 'NextStyles', {
            get: function () {
                return {
                    height: Dc.NormalSlideHeight,
                    left: 0,
                    top: 0
                };
            }
        });
        //...................................
        Object.defineProperty(Dc, 'Index', {
            get: function () {
                if (_Index === undefined) return -1;

                return _Index;
            },

            set: function (Value) {
                _Index = Value;
            }
        });
        //...................................
        Object.defineProperty(Dc, 'Width', {
            get: function () {
                return $Item.width();
            }
        });
        //...................................
        Object.defineProperty(Dc, 'Height', {
            get: function () {
                return $Item.height();
            }
        });
        //...................................
        Object.defineProperty(Dc, 'NormalSlideHeight', {
            get: function () {
                return Dc.Height;
            }
        });
        //...................................
        // /PROPERTIES
        //--------------------------------------------
        init();
        //--------------------------------------------
    });
};
