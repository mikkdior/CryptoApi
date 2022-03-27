jQuery.fn.dcTpl = function (Callback, UserConf) {
    UserConf = (UserConf === undefined) ? {} : jQuery.dc.f.getArgs(arguments, 1);
    // PRIVATE FIELDS
    var $ = jQuery;
    var $Self = this;
    jQuery.fn.dcTpl.dc = jQuery.fn.dcTpl.dc || {};
    var Static = jQuery.fn.dcTpl.dc;
    Static.templates = Static.templates || {};
    var Conf = {};
    var Css = $Self.selector;
    // /PRIVATE FIELDS
    //--------------------------------------------
    // PUBLIC FIELDS
    // /PUBLIC FIELDS
    //--------------------------------------------
    // INIT
    function init () {
        if (Callback === undefined) return getTpl.call($Self[0]);
        if (typeof Callback === 'string') return doAction(Callback, UserConf);
        setVars();
        setEvents();
    }
    //...................................
    function setVars () {
        $.extend(Conf, UserConf[0]);
    }
    //...................................
    function setEvents () {
        $.dc.f.ready(Css, onReady, Conf);
    }
    //...................................
    // /INIT
    //--------------------------------------------
    // PUBLIC
    //...................................
    // /PUBLIC
    //--------------------------------------------
    // EVENTS
    function onReady () {
        Callback.call(this, $, getTpl.call(this));
        getTpl.call(this).trigger('on_ready');
    }
    //...................................
    // /EVENTS
    //--------------------------------------------
    // PRIVATE
    function addTpl () {
        var $self = $(this);
        var self = $self[0];
        self.dc = self.dc || {};
        if (self.dc.tpl) return;
        self.dc.tpl = new CTpl(self, Css);
    }
    //...................................
    function getTpl () {
        var $self = $(this);
        var self = $self[0];
        self.dc = self.dc || {};
        if (!self.dc.tpl) addTpl.call(this);
        return self.dc.tpl;
    }
    //...................................
    function doAction (Action, Data) {
        if (Action === 'on') return doOnAction(Data);
        $Self.each(function () {
            var tpl = getTpl.call(this);
            if (typeof tpl[Action] !== 'function') return;
            tpl[Action].apply(this, Data);
        });
        return $Self;
    }
    //...................................
    function doOnAction (Data) {
        $Self.each(function () {
            var tpl = getTpl.call(this);
            tpl.on(Data[0], true, Data[1]);
        });
        return $Self;
    }
    //...................................
    // /PRIVATE
    //--------------------------------------------
    // PROPERTIES
    //...................................
    // /PROPERTIES
    //=====================================================
    function CTpl (Element, Css) {
        var Self = this;
        var EventPrefix = 'dc_tpl_';
        var _ready = false;
        //--------------------------------------------
        function init () {
            setEvents();
        }
        //--------------------------------------------
        function setEvents () {
            Self.on('on_ready', onReady);
        }
        //--------------------------------------------
        function onReady() {
            _ready = true;
        }
        //--------------------------------------------
        Self.on = function (E, Only, Callback) {
            E = EventPrefix + E;
            var func = typeof Only === 'function' ? Only : Callback
            if (typeof Callback === 'function' && Only)
                Self.$Item.on(E, func);
            else
                $('body').on(E, Css, func);
        }
        //--------------------------------------------
        Self.trigger = function (E, Data) {
            Data = Data ? $.dc.f.getArgs(arguments, 1) : undefined;
            E = EventPrefix + E;
            Self.$Item.trigger(E, Data);
        }
        //--------------------------------------------
        Self.linkTrigger = function (E, Data) {
            Data = Data ? $.dc.f.getArgs(arguments, 1) : undefined;
            return function () {
                var args = Data ? Data : [];
                args.unshift(E);
                // TODO: потестить apply
                Self.trigger.apply(this, args);
            }
        }
        //--------------------------------------------
        Object.defineProperty(Self, '$Item', {
            get: function () {
                return $(Element);
            }
        });
        //--------------------------------------------
        Object.defineProperty(Self, '$Items', {
            get: function () {
                return $(Css);
            }
        });
        //--------------------------------------------
        Object.defineProperty(Self, 'IsReady', {
            get: function () {
                return _ready;
            }
        });
        //--------------------------------------------
        init();
    }
    //=====================================================
    return init();
    //--------------------------------------------
};
