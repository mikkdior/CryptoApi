/**
 * jasdf
 * @memberof dc.f
 * @name ready
 * @alias ready
 * @function
 * @param  {string} Value asdfl;kj
 * @return {bool}       adflk;j
 */
jQuery.dc.f.tpl = function (Css, Callback, UserConf) {
    Callback = (Callback === undefined) ? false : Callback;
    UserConf = (UserConf === undefined) ? {} : UserConf;
    // PRIVATE FIELDS
    var $ = jQuery;
    var Self = this;
    Self.tpl.dc = Self.tpl.dc || {};
    var Static = Self.tpl.dc;
    Static.templates = Static.templates || {};
    var Conf = {};
    var $Css;
    // /PRIVATE FIELDS
    //--------------------------------------------
    // PUBLIC FIELDS
    // /PUBLIC FIELDS
    //--------------------------------------------
    // INIT
    function init () {
        if (Callback === false) return getTpl();
        setVars();
        addTpl();
        setEvents();
    }
    //...................................
    function setVars () {
        $.extend(Conf, UserConf);
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
        Callback.call(this, $, Static.templates[Css]);
    }
    //...................................
    // /EVENTS
    //--------------------------------------------
    // PRIVATE
    function addTpl () {
        if (Static.templates[Css]) return;
        Static.templates[Css] = new CTpl(Css);
    }
    //...................................
    function getTpl () {
        if (!Static.templates[Css]) addTpl();
        return Static.templates[Css];
    }
    //...................................
    // /PRIVATE
    //--------------------------------------------
    // PROPERTIES
    //...................................
    // /PROPERTIES
    //=====================================================
    function CTpl (Css) {
        var Self = this;
        //--------------------------------------------
        function init () {
        }
        //--------------------------------------------
        Self.on = function (E, Callback) {
            $('body').on(E, Css, Callback);
        }
        //--------------------------------------------
        Object.defineProperty(Self, '$Items', {
            get: function () {
                return $(Css);
            }
        });
        //--------------------------------------------
        init();
    }
    //=====================================================
    return init();
    //--------------------------------------------
};
