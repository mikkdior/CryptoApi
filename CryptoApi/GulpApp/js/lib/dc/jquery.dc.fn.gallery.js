/**
 * jasdf
 * @memberof module:jQueryPlugins
 * @name dcGallery
 * @alias dcGallery
 * @function
 * @param  {string} Value asdfl;kj
 * @return {bool}       adflk;j
 */
jQuery.fn.ssGallery = function (Attr) {
    var $ = jQuery;
    var Self = this;

    var Conf = {
        SlidesCss: '.dcj-slide',
        SketchesCss: '.dcj-sketch',
        NextButtonCss: '.dcj-next-button',
        PrevButtonCss: '.dcj-prev-button',
        ActiveClass: 'dcj-active',

        Sketches: true,
        ChangeOnMouseMove: true,
        Animation: 'fade',
        AnimationTime: 300,

        onBeforeChange: function (Data) {},
        onAfterChange: function (Data) {},
        onSlideClick: function (Data) {},
        onSlideDblClick: function (Data) {}
    };

    $.extend(Conf, Attr);

    return this.each(function () {
        // PRIVATE FIELDS
        var Item = this;
        Item.dcGallery = {};
        var Dc = Item.dcGallery;
        var $Item = $(Item);

        var _Index;
        // /PRIVATE FIELDS
        //--------------------------------------------
        // PUBLIC FIELDS
        // /PUBLIC FIELDS
        //--------------------------------------------
        // INIT
        function init () {
            setVars();
            setEvents();
        }
        //...................................
        function setVars () {
            Dc.$Slides.each(function (Index) {
                this.dcGallery = (this.dcGallery) ? this.dcGallery : {};
                this.dcGallery.Index = Index;
            });

            Ds.$Sketches.each(function (Index) {
                this.dcGallery = (this.dcGallery) ? this.dcGallery : {};
                this.dcGallery.Index = Index;
            });

            var animation_time = Conf.AnimationTime;
            Conf.AnimationTime = 0;
            Dc.Index = 0;
            Conf.AnimationTime = animation_time;
        }
        //...................................
        function setEvents () {
            $Item.on('dblclick', Conf.SlidesCss, onSlideDblclick);
            $Item.on('click', Conf.SketchesCss, onSketchClick);
            $Item.on('mouseover', Conf.SketchesCss, onSketchClick);
            $Item.on('click', Conf.NextButtonCss, onNextButtonClick);
            $Item.on('click', Conf.PrevButtonCss, onPrevButtonClick);

            if (Conf.ChangeOnMouseMove)
                $Item.on('mousemove', Conf.SlidesCss, onMouseMove);
        }
        //...................................
        // /INIT
        //--------------------------------------------
        // PUBLIC
        //...................................
        // /PUBLIC
        //--------------------------------------------
        // EVENTS
        function onChangeIndex (Value) {
            Dc.hide();
            Dc.show();

            var active_slide = $(Dc.$Slides[Value]);
            Dc.$ActiveSlide = active_slide;

            if (Conf.Sketches) {
                var active_sketch = $(Dc.$Sketches[Value]);
                Dc.$ActiveSketch = active_sketch;
            }
        }
        //...................................
        function onNextButtonClick () {
            var count = Dc.$Slides.length;
            var index = Dc.Index + 1;
            if (count == index) index = 0;

            Dc.Index = index;

            return false;
        }
        //...................................
        function onPrevButtonClick () {
            var count = Dc.$Slides.length;
            var index = Dc.Index - 1;
            if (index < 0) index = count - 1;

            Dc.Index = index;

            return false;
        }
        //...................................
        function onSketchClick () {
            Dc.Index = this.dsGallery.Index;

            return false;
        }
        //...................................
        function onSlideDblclick () {
            doUserEvent('onSlideDblClick', {gallery: $Item, slide: Dc.$ActiveSlide});

            return false;
        }
        //...................................
        function onMouseMove (e) {
            var x = e.pageX - $Item.offset().left;
            Dc.Index = getIndexByMouse(x);
        }
        //...................................
        // /EVENTS
        //--------------------------------------------
        // PRIVATE
        function doUserEvent (Name, Data) {
            if (typeof(Conf[Name]) == 'function') return Conf[Name](Data);
        }
        //...................................
        function hideFade (Time) {
            var time = (Time === undefined) ? Conf.AnimationTime : Time;

            Dc.$Slides.stop().fadeTo(time, 0);
        }
        //...................................
        function showFade (Time, Index) {
            var time = (Time === undefined) ? Conf.AnimationTime : Time;
            var index = (Index === undefined) ? Dc.Index : Index;

            $(Dc.$Slides[index]).stop().fadeTo(time, 1);
        }
        //...................................
        function getIndexByMouse (X) {
            var width = $Item.width();
            var count = Dc.$Slides.length;
            var index = Math.ceil(X / (width / count)) - 1;
            index = (index < 0) ? 0 : index;
            index = (index > (count - 1)) ? (count - 1) : index;

            return index;
        }
        //...................................
        // /PRIVATE
        //--------------------------------------------
        // PROPERTIES
        Object.defineProperty(Dc, 'Index', {
            set: function (Value) {
                var value = doUserEvent('onBeforeChange', {gallery: $Item, value: Value});
                if (value === false || Value == _Index) return;

                value = (value == undefined) ? Value : value;
                _Index = value;

                onChangeIndex(value);
                doUserEvent('onAfterChange', {gallery: $Item, value: Value});
            },

            get: function () {
                return _Index;
            }
        });
        //...................................
        Object.defineProperty(Dc, '$Slides', {
            get: function () {
                return $Item.find(Conf.SlidesCss);
            }
        });
        //...................................
        Object.defineProperty(Dc, '$Sketches', {
            get: function () {
                return $Item.find(Conf.SketchesCss);
            }
        });
        //...................................
        Object.defineProperty(Dc, '$NextButton', {
            get: function () {
                return $Item.find(Conf.NextButtonCss);
            }
        });
        //...................................
        Object.defineProperty(Dc, '$PrevButton', {
            get: function () {
                return $Item.find(Conf.PrevButtonCss);
            }
        });
        //...................................
        Object.defineProperty(Dc, '$ActiveSlide', {
            get: function () {
                var css = Conf.SlidesCss + '.' + Conf.ActiveClass;
                return $Item.find(css);
            },

            set: function ($Slide) {
                Dc.$Slides.removeClass(Conf.ActiveClass);
                $Slide.addClass(Conf.ActiveClass);
            }
        });
        //...................................
        Object.defineProperty(Dc, '$ActiveSketch', {
            get: function () {
                var css = Conf.SketchesCss + '.' + Conf.ActiveClass;
                return $Item.find(css);
            },

            set: function ($Sketch) {
                Dc.$Sketches.removeClass(Conf.ActiveClass);
                $Sketch.addClass(Conf.ActiveClass);
            }
        });
        //...................................
        Object.defineProperty(Dc, 'show', {
            get: function () {
                switch (Conf.Animation) {
                    case 'fade': return showFade;

                    default: return showFade;
                }
            }
        });
        //...................................
        Object.defineProperty(Dc, 'hide', {
            get: function () {
                switch (Conf.Animation) {
                    case 'fade': return hideFade;

                    default: return hideFade;
                }
            }
        });
        //...................................
        // /PROPERTIES
        //--------------------------------------------
        init();
        //--------------------------------------------
    });
};
