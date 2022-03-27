/**
 * jasdf
 * @memberof dc.f
 * @name ready
 * @alias ready
 * @function
 * @param  {string} Value asdfl;kj
 * @return {bool}       adflk;j
 */
jQuery.dc.f.ready = function (Css, Callback, UserConf) {
    Callback = (Callback === undefined) ? false : Callback;
    UserConf = (UserConf === undefined) ? {} : UserConf;
    // PRIVATE FIELDS
    var $ = jQuery;
    var ReadyAttr       = 'dc_ready';
    var ReadyAttrValue  = 'ready';

    var Self = this;
    var Static = Self.ready.prototype;

    var Actions = {};

    var Conf = {
        auto_follow: false,
        timeout: 500
    };

    var $Css = $(Css);
    // /PRIVATE FIELDS
    //--------------------------------------------
    // PUBLIC FIELDS
    // /PUBLIC FIELDS
    //--------------------------------------------
    // INIT
    function init () {
        if (typeof(Callback) != 'function') return doAction(Css, Callback);

        setVars();
        setEvents();

        Actions.check();
        if (Conf.auto_follow) run();
    }
    //...................................
    function setVars () {
        $.extend(Conf, UserConf);

        Static.Css = (Static.Css) ? Static.Css : [];
        addCss(Css);
    }
    //...................................
    function setEvents () {
        if (!Static.HasBodyReady) {
            $('body').ready(onBodyReady);
            Static.HasBodyReady = true;
        }
    }
    //...................................
    // /INIT
    //--------------------------------------------
    // PUBLIC
    Actions.check = function (Data) {
        if (!Static.Css) return;

        Static.Css.forEach(function (Item, Index) {
            $(Item.css).each(function () {
                onReady.call($(this), Item.callback, Index);
            });
        });
    };
    //...................................
    // /PUBLIC
    //--------------------------------------------
    // EVENTS
    function onReady (Callback, Index) {
        var attr = ReadyAttr + '-' + Index;
        if (this[0][attr] == ReadyAttrValue) return;

        Callback.call(this, $);
        this[0][attr] = ReadyAttrValue;
    }
    //...................................
    function onTime () {
        Actions.check();
    }
    //...................................
    function onBodyReady () {
        Actions.check();
    }
    //...................................
    // /EVENTS
    //--------------------------------------------
    // PRIVATE
    function addCss (Css) {
        Static.Css.push({
            'css': Css,
            'callback': Callback
        });
    }
    //...................................
    function run () {
        if (Static.runing) return;

        setInterval(onTime, 10);

        Static.runing = true;
    }
    //...................................
    function doAction (Action, Data) {
        if (typeof(Actions[Action]) == 'function') Actions[Action](Data);
    }
    //...................................
    // /PRIVATE
    //--------------------------------------------
    // PROPERTIES
    //...................................
    // /PROPERTIES
    //--------------------------------------------
    init();
    //--------------------------------------------
};
