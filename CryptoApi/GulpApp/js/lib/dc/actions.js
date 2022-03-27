jQuery(function ($) {
    var Self = $.dc.actions;
    //--------------------------------------------
    //Self.template = function (Data) {
    //
    //};
    //--------------------------------------------
    Self.newProject = function (Data) {
        console.log('new project');
    };
    //--------------------------------------------
    Self.openProject = function (Data) {
        console.log('open project');
    }
    //--------------------------------------------
    Self.saveProject = function (Data) {
        console.log('save project');
    }
    //--------------------------------------------
    Self.saveProjectAs = function (Data) {
        console.log('save project as');
    }
    //--------------------------------------------
    Self.exportProject = function (Data) {
        console.log('export project');
    }
    //--------------------------------------------
    Self.importProject = function (Data) {
        console.log('import project');
    }
    //--------------------------------------------
    Self.search = function (Word, Files) {
        console.log('search');
    }
    //--------------------------------------------
    Self.translateApp = function (From, To, Word) {
        var tpl = $('.dc-lang').dcTpl();
        if (!tpl.isDataReady()) return;

        From = From ? From : tpl.getOldLang();
        To = To ? To : tpl.getLang();

        if (Word)
            return $.dc.f.tl(From, To, Word);
        else
            $('.ssj-tl').dcTl(From, To);
    }
    //--------------------------------------------
    Self.logTl = function () {
        var words = $.dc.f.tlGetWords();
        var json = JSON.stringify(words, null, 4);
        console.log(json);
    }
    //--------------------------------------------
});
