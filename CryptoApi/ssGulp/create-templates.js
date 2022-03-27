var Fs = require('fs');
var ReplaceWord = /template/g

function CCreateTemplates (Path) {
    // PRIVATE FIELDS
    var Self = this;

    var TemplatePath = 'GulpApp/files-template/';
    var IncludesFilePath = 'includes.pug';
    var ListFilePath = '!_list.struct';
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
        TemplatePath = TemplatePath;
        IncludesFilePath = Path + IncludesFilePath;
        ListFilePath = Path + ListFilePath;
    }
    //...................................
    function setEvents () {}
    //...................................
    // /INIT
    //--------------------------------------------
    // PUBLIC
    Self.Create = function () {
        var list = getTmpList();

        list.forEach(function (Name) {
            createTemplate(Name);
        });
    };
    //...................................
    // /PUBLIC
    //--------------------------------------------
    // EVENTS
    //...................................
    // /EVENTS
    //--------------------------------------------
    // PRIVATE
    function getTmpList () {
        var content = Fs.readFileSync(ListFilePath, 'utf8');
        var list = content.split("\r\n");
        var result = [];

        list.forEach(function (Item) {
            var item = Item.trim();
            if (item) result.push(item);
        });

        return result;
    }
    //...................................
    function createTemplate (Name) {
        var new_path = Path;

        copyDir(TemplatePath, new_path, function (content) {
            return filterContent(content, Name);
        }, function (file) {
            return filterFileName(file, Name);
        });
    }
    //...................................
    function copyDir(from, to, filter_content, filter_name, callback) {
        let files = Fs.readdirSync(from);

        for (file of files) {
            let path = to + filter_name(file);
            if (Fs.existsSync(path)) continue;

            let old_path = from + file;
            let content = Fs.readFileSync(old_path, 'utf8');
            content = filter_content(content);
            Fs.writeFileSync(path, content);
        }
    }
    //...................................
    function filterContent(content, template_name) {
        content = content.replace(ReplaceWord, template_name);
        content = content.replace(/\/\/- /g, '');

        return content;
    }
    //...................................
    function filterFileName(file_name, template_name) {
        let key = 'cshtml';
        let ext = file_name.replace('template.', '');
        ext = ext == key ? ext : key + '.' + ext;

        return template_name + '.' + ext;
    }
    //...................................
    // /PRIVATE
    //--------------------------------------------
    // PROPERTIES
    /*
    Object.defineProperty(Ss, 'Test', {
            _Test = Value;
        },

        get: function () {
            return _Test;
        }
    });
    */
    //...................................
    // /PROPERTIES
    //--------------------------------------------
    init();
    //--------------------------------------------
}

module.exports = CCreateTemplates;
