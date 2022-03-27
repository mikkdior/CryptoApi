// Плагин слушает Css свойства с определённым периодом
// Если свойство меняется - вызывается для соответствующего элемента событие в формате:
// on_<имя свойства>_change
// К примеру для свойства height, имя события будет следующим:
// on_height_change
//
// Css: string | array - имена css-свойств, которые нужно слушать
jQuery.fn.dcListen = function (Css, Callback) {
    var $ = jQuery;
    var $This = $(this);
    Css = (typeof Css === 'string') ? [Css] : Css;
    $.fn.dcListen.ss = $.fn.dcListen.dc || {};
    var Data = $.fn.ssListen.dc;
    var Interval = 20;
    //...................................
    function init () {
        setEvents();
        addItems();
    }
    //...................................
    function setEvents () {
        if (!Data.timer)
            Data.timer = setInterval(onTime, Interval);
    }
    //...................................
    function onTime () {
        if (!Data.items) return;

        for (var i in Data.items) {
            var item = Data.items[i];

            for (var j in item.dc.listen.css) {
                var css = item.dc.listen.css[j];

                if (!checkCss.call(item, css)) {
                    onChange.call(item, css);
                    saveCss.call(item, css);
                }
            }
        }
    }
    //...................................
    function onChange (Css) {
        var $this = $(this);
        var event_name = getEventName(Css);

        $this.trigger(event_name);
    }
    //...................................
    function checkCss (css) {
        var $this = $(this);
        var val = $this.css(css);

        return val === this.dc.listen.old_css[css];
    }
    //...................................
    function getEventName(Css) {
        return 'on_' + Css + '_change';
    }
    //...................................
    function saveCss (Css) {
        var $this = $(this);
        var css = this.dc.listen.css;
        this.dc.listen.old_css = this.dc.listen.old_css || {};
        var old_css = this.dc.listen.old_css;

        if (Css !== undefined) {
            old_css[Css] = $this.css(Css);
            return;
        }

        for (var i in css) {
            old_css[css[i]] = $this.css(css[i]);
        }
    }
    //...................................
    function hasItem (item) {
        return item.dc && item.dc.listen;
    }
    //...................................
    function addItems () {
        linkCallback();

        $This.each(function () {
            if (!hasItem(this)) {
                this.dc = this.dc || {};
                this.dc.listen = this.dc.listen || {}
                Data.items = Data.items || [];
                Data.items.push(this);
            }

            this.dc.listen.css = this.dc.listen.css || [];
            this.dc.listen.css = $.dc.f.arrayUnique(this.dc.listen.css.concat(Css));

            saveCss.call(this);
        });
    }
    //...................................
    function linkCallback () {
        if (typeof Callback !== 'function') return;

        var events = '';
        for (var i in Css) {
            events += getEventName(Css[i]) + ' ';
        }

        events = events.trim();
        $This.on(events, Callback);
    }
    //...................................
    init();
    return this;
};
//--------------------------------------------
