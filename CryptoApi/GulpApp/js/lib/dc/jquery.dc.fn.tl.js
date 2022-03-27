jQuery.fn.dcTl = function (From, To) {
    // PRIVATE FIELDS
    var $ = jQuery;
    var $Self = this;
    jQuery.fn.dcTl.dc = jQuery.fn.dcTl.dc || {};
    var Static = jQuery.fn.dcTl.dc;
    Static.callbacks = Static.callbacks || [];
    var F = $.dc.f;
    // /PRIVATE FIELDS
    //--------------------------------------------
    // PUBLIC FIELDS
    // /PUBLIC FIELDS
    //--------------------------------------------
    // INIT
    function init () {
        if (!Static.data && !To) {
            loadData(From);
            return;
        }
        if (!To || !Static.data) return;
        setVars();
        setEvents();
        translate();
    }
    //...................................
    function setVars () {}
    //...................................
    function setEvents () {}
    //...................................
    // /INIT
    //--------------------------------------------
    // PUBLIC
    F.tl = function (From, To, Word) {
        if (!Word) return false;
        for (var i in Static.data.words) {
            var from = Static.data.words[i][From];
            if (from === Word) return Static.data.words[i][To];
        }
        onNotTl(From, Word);
        return false;
    }
    //...................................
    F.tlGetWords = function () {
        return Static.data.words;
    }
    //...................................
    F.tlGetData = function () {
        return Static.data;
    }
    //...................................
    F.tlOnReady = function (Callback) {
        if (Static.data)
            Callback(Static.data);
        else
            Static.callbacks.push(Callback);
    }
    //...................................
    // /PUBLIC
    //--------------------------------------------
    // EVENTS
    function onReady () {
        doCallbacks();
    }
    //...................................
    function onNotTl (From, Word) {
        var item = {};
        item[From] = Word;
        for (var i in Static.data.langs) {
            if (Static.data.langs[i] === From) continue;
            item[Static.data.langs[i]] = '';
        }
        Static.data.words.push(item);
    }
    //...................................
    // /EVENTS
    //--------------------------------------------
    // PRIVATE
    function loadData (Url) {
        if (Static.busy) return;
        $.get(Url, function (Data) {
            Static.data = Data;
            onReady();
            Static.busy = false;
        });
        Static.busy = true;
    }
    //...................................
    function translate () {
        $Self.each(function () {
            var $this = $(this);
            var html = $this.html();
            var placeholder = $this.attr('placeholder');
            var title = $this.attr('title');
            var to;
            if (to = F.tl(From, To, html))
                $this.html(to);
            if (to = F.tl(From, To, placeholder))
                $this.attr('placeholder', to);
            if (to = F.tl(From, To, title))
                $this.attr('title', to);
        });
    }
    //...................................
    function doCallbacks () {
        while (Static.callbacks.length) {
            var func = Static.callbacks.pop();
            func(Static.data)
        }
    }
    //...................................
    // /PRIVATE
    //--------------------------------------------
    // PROPERTIES
    //...................................
    // /PROPERTIES
    //--------------------------------------------
    return init();
    //--------------------------------------------
};
