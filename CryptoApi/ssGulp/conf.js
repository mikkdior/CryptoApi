//-----------------------------------------------------
// REQUIRE
var Options = require('./conf/options');
var Uri = require('./conf/uri');
// /REQUIRE
//-----------------------------------------------------
// CODE
function COptions () {

}
//...........................................
function CUri () {
    // PRIVATE FIELDS
    var _Self = this;
    var _Uri = Uri;
    var _Options = Options;
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
    function setVars () {}
    //...................................
    function setEvents () {}
    //...................................
    // /INIT
    //--------------------------------------------
    // PUBLIC
    //...................................
    // /PUBLIC
    //--------------------------------------------
    // EVENTS
    //...................................
    // /EVENTS
    //--------------------------------------------
    // PRIVATE
    //...................................
    // /PRIVATE
    //--------------------------------------------
    // PROPERTIES
    /*
    Содержит объект из ./ss-gulp/conf/options.json
     */
    Object.defineProperty(_Self, 'Options', {
        get: function () { return _Options; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к корню gulp-проекта.

    Пример: "./".
     */
    Object.defineProperty(_Self, 'Base', {
        get: function () { return './'; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории, куда должны сохраняться архивы.

    Пример: "./zip/".
     */
    Object.defineProperty(_Self, 'Zip', {
        get: function () { return _Self.Base + _Uri.Zip; }
    });
    //...................................
    /*
    Содержит на основе файла ./ss-gulp/conf/uri.json
    имя файла архива проекта.

    Пример: "archive.zip".
     */
    Object.defineProperty(_Self, 'ZipFile', {
        get: function () { return _Uri.ZipFile; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории для разработки.

    Пример: "./app/".
     */
    Object.defineProperty(_Self, 'In', {
        get: function () { return _Self.Base + _Uri.In; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с компонентами в исходной директории.

    Пример: "./app/components/".
     */
    Object.defineProperty(_Self, 'InComponents', {
        get: function () { return _Self.In + _Uri.InComponents; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с картинками в исходной директории.

    Пример: "./app/images/".
     */
    Object.defineProperty(_Self, 'InImages', {
        get: function () { return _Self.In + _Uri.InImages; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с картинками для svg-спрайтов в исходной директории.

    Пример: "./app/images/svg-sprite/".
     */
    Object.defineProperty(_Self, 'InSvgSprite', {
        get: function () { return _Self.InImages + _Uri.InSvgSprite; }
    });
    //...................................
    /*
    Содержит на основе файла ./ss-gulp/conf/uri.json
    имя css-файла, в котором должны храниться стили спрайтов.

    Пример: "sprite.css".
     */
    Object.defineProperty(_Self, 'InSpriteFile', {
        get: function () { return _Uri.InSpriteFile; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с картинками для контента.

    Пример: "./app/pictures/".
     */
    Object.defineProperty(_Self, 'InPictures', {
        get: function () { return _Self.In + _Uri.InPictures; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории со шрифтами в исходной директории.

    Пример: "./app/fonts/".
     */
    Object.defineProperty(_Self, 'InFonts', {
        get: function () { return _Self.In + _Uri.InFonts; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с js-файлами в исходной директории.

    Пример: "./app/js/".
     */
    Object.defineProperty(_Self, 'InJs', {
        get: function () { return _Self.In + _Uri.InJs; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с js-библиотеками в исходной директории.

    Пример: "./app/js/lib/".
     */
    Object.defineProperty(_Self, 'InJsLib', {
        get: function () { return _Self.InJs + _Uri.InJsLib; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с pug-файлами в исходной директории.

    Пример: "./app/pug/".
     */
    Object.defineProperty(_Self, 'InPug', {
        get: function () { return _Self.In + _Uri.InPug; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории со стилями в исходной директории.

    Пример: "./app/scss/".
     */
    Object.defineProperty(_Self, 'InScss', {
        get: function () { return _Self.In + _Uri.InScss; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с css-библиотеками в исходной директории.

    Пример: "./app/scss/lib/".
     */
    Object.defineProperty(_Self, 'InScssLib', {
        get: function () { return _Self.InScss + _Uri.InScssLib; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с базовыми стилями в исходной директории.

    Пример: "./app/scss/base/".
     */
    Object.defineProperty(_Self, 'InScssBase', {
        get: function () { return _Self.InScss + _Uri.InScssBase; }
    });
    //...................................
    /*
    Содержит на основе файла ./ss-gulp/conf/uri.json
    имя файла стилей шаблонов в директории стилей в исходной директории.

    Пример: "_templates.scss".
     */
    Object.defineProperty(_Self, 'InScssTemplatesFile', {
        get: function () { return _Uri.InScssTemplatesFile; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с шаблонами в исходной директории.

    Пример: "./app/templates/".
     */
    Object.defineProperty(_Self, 'InTemplates', {
        get: function () { return _Uri.InTemplates; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с библиотекой шаблонов в исходной директории.

    Пример: "./app/templates/".
     */
     Object.defineProperty(_Self, 'InTemplatesLib', {
        get: function () { return _Self.In + _Uri.InTemplatesLib; }
    });
    //...................................
    /*
    Содержит название файла опций библиотек
    на основе файла ./ss-gulp/conf/uri.json

    Пример: "options.json".
     */
     Object.defineProperty(_Self, 'InLibOptionsFile', {
        get: function () { return _Uri.InLibOptionsFile; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к pro-директории.

    Пример: "./dest/".
     */
    Object.defineProperty(_Self, 'Out', {
        get: function () { return _Self.Base + _Uri.Out; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории со стилями в pro-директории.

    Пример: "./dest/css/".
     */
    Object.defineProperty(_Self, 'OutCss', {
        get: function () { return _Self.Out + _Uri.OutCss; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории со шрифтами в pro-директории.

    Пример: "./dest/fonts/".
     */
    Object.defineProperty(_Self, 'OutFonts', {
        get: function () { return _Self.Out + _Uri.OutFonts; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с картинками в pro-директории.

    Пример: "./dest/images/".
     */
    Object.defineProperty(_Self, 'OutImages', {
        get: function () { return _Self.Out + _Uri.OutImages; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    имя файла картинки спрайта.

    Пример: "sprite.png".
     */
    Object.defineProperty(_Self, 'OutSpriteFile', {
        get: function () { return _Uri.OutSpriteFile; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с картинками для контента в pro-директории.

    Пример: "./dest/pictures/".
     */
    Object.defineProperty(_Self, 'OutPictures', {
        get: function () { return _Self.Out + _Uri.OutPictures; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с js-файлами в pro-директории.

    Пример: "./dest/js/".
     */
    Object.defineProperty(_Self, 'OutJs', {
        get: function () { return _Self.Out + _Uri.OutJs; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    к директории с шаблонами в pro-директории.

    Пример: "./dest/templates/".
     */
    Object.defineProperty(_Self, 'OutTemplates', {
        get: function () { return _Self.Out + _Uri.OutTemplates; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    имя главного css-файла в pro-директории.

    Пример: "style.css".
     */
    Object.defineProperty(_Self, 'OutCssFile', {
        get: function () { return _Uri.OutCssFile; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    css-файла с библиотеками в pro-директории.

    Пример: "lib.css".
     */
    Object.defineProperty(_Self, 'OutCssLibFile', {
        get: function () { return _Uri.OutCssLibFile; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    имя главного js-файла в pro-директории.

    Пример: "main.js".
     */
    Object.defineProperty(_Self, 'OutJsFile', {
        get: function () { return _Uri.OutJsFile; }
    });
    //...................................
    /*
    Содержит путь на основе файла ./ss-gulp/conf/uri.json
    js-файла с библиотеками в pro-директории.

    Пример: "lib.js".
     */
    Object.defineProperty(_Self, 'OutJsLibFile', {
        get: function () { return _Uri.OutJsLibFile; }
    });
    //...................................
    /*
    Содержит объект опций scss/lib/options.json
     */
    Object.defineProperty(_Self, 'InScssLibOptions', {
        get: function () {
            var options_path = '.' + _Self.InScssLib + _Self.InLibOptionsFile;

            return require(options_path);
        }
    });
    //...................................
    /*
    Содержит объект опций components/options.json
     */
    Object.defineProperty(_Self, 'InComponentsOptions', {
        get: function () {
            var options_path = '.' + _Self.InComponents + _Self.InLibOptionsFile;

            return require(options_path);
        }
    });
    //...................................
    /*
    Содержит объект опций js/lib/options.json
     */
    Object.defineProperty(_Self, 'InJsLibOptions', {
        get: function () {
            var options_path = '.' + _Self.InJsLib + _Self.InLibOptionsFile;

            return require(options_path);
        }
    });
    //...................................
    /*
    Содержит массив путей на основе файла ./ss-gulp/conf/options.json
    к библиотечным файлам со стилями в исходной директории.

    Пример: "['./app/scss/*.*']".
     */
    Object.defineProperty(_Self, 'InScssLibPaths', {
        get: function () {
            var list = [];
            var options = _Self.InScssLibOptions;
            if (!options) return list;

            for (var key in options.lib) {
                if (options.lib[key])
                    list.push(_Self.InScssLib + key + '.*');
            }

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей на основе файла ./ss-gulp/conf/options.json
    к файлам со стилями компонентов в исходной директории.

    Пример: "['./app/components/ ** /*.css']".
     */
    Object.defineProperty(_Self, 'InScssComponentsPaths', {
        get: function () {
            var list = [];
            var options = _Self.InComponentsOptions;
            if (!options) return list;

            for (var key in options.lib) {
                if (options.lib[key]) {
                    list.push(_Self.InComponents + key + '/*.scss');
                    list.push(_Self.InComponents + key + '/*.css');
                }
            }

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей на основе файла ./ss-gulp/conf/options.json
    ко всем библиотечным файлам со стилями в исходной директории.

    Пример: "['./app/ ** /*.css']".
     */
    Object.defineProperty(_Self, 'InAllScssLibPaths', {
        get: function () {
            return _Self.InScssLibPaths.concat(_Self.InScssComponentsPaths);
        }
    });
    //...................................
    /*
    Содержит массив путей на основе файла ./ss-gulp/conf/options.json
    к библиотечным js-файлам в исходной директории.

    Пример: "['./app/js/lib/*.js']".
     */
    Object.defineProperty(_Self, 'InJsLibPaths', {
        get: function () {
            var list = [];
            var options = _Self.InJsLibOptions;
            if (!options) return list;

            for (var key in options.lib) {
                if (options.lib[key]) {
                    list.push(_Self.InJsLib + key + '.js');
                }
            }

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей на основе файла ./ss-gulp/conf/options.json
    к библиотечным js-файлам в компонентах в исходной директории.

    Пример: "['./app/components/ ** /*.js']".
     */
    Object.defineProperty(_Self, 'InJsComponentsPaths', {
        get: function () {
            var list = [];
            var options = _Self.InComponentsOptions;
            if (!options) return list;

            for (var key in options.lib) {
                if (options.lib[key]) {
                    list.push(_Self.InComponents + key + '/*.js');
                }
            }

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей на основе файла ./ss-gulp/conf/options.json
    ко всем библиотечным js-файлам в исходной директории.

    Пример: "['./app/ ** /*.js']".
     */
    Object.defineProperty(_Self, 'InAllJsLibPaths', {
        get: function () {
            return _Self.InJsLibPaths.concat(_Self.InJsComponentsPaths);
        }
    });
    //...................................
    /*
    Содержит массив путей
    к основным js-файлам в исходной директории.

    Пример: "['./app/js/*.js']".
     */
    Object.defineProperty(_Self, 'InJsCompilePaths', {
        get: function () {
            var list = [
                _Self.InJs + '*.js',
                _Self.InTemplates + '**/*.js'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей
    к основным файлам со стилями в исходной директории.

    Пример: "['./app/scss/*.scss']".
     */
    Object.defineProperty(_Self, 'InScssCompilePaths', {
        get: function () {
            var list = [
                _Self.InScss + 'style.scss'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей
    к основным pug-файлам в исходной директории.

    Пример: "['./app/*.pug']".
     */
    Object.defineProperty(_Self, 'InPugCompilePaths', {
        get: function () {
            var list = [
                _Self.In + '*.pug'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей
    к файлам со шрифтами в исходной директории.

    Пример: "['./app/fonts/*.*']".
     */
    Object.defineProperty(_Self, 'InFontsCompilePaths', {
        get: function () {
            var list = [
                _Self.InFonts + '*',
                _Self.InFonts + '**/*'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей
    к файлам картинок в исходной директории.

    Пример: "['./app/images/*.*']".
     */
    Object.defineProperty(_Self, 'InImagesCompilePaths', {
        get: function () {
            var list = [
                _Self.InImages + '*.*'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей
    к файлам картинок для контента в исходной директории.

    Пример: "['./app/pictures/*.*']".
     */
    Object.defineProperty(_Self, 'InPicturesCompilePaths', {
        get: function () {
            var list = [
                _Self.InPictures + '*.*'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей
    к файлам картинок для спрайтов в исходной директории.

    Пример: "['./app/images/sprite/*.*']".
     */
    Object.defineProperty(_Self, 'InSpriteCompilePaths', {
        get: function () {
            var list = [
                _Self.InSprite + '*.*'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей
    к файлам картинок для svg-спрайтов в исходной директории.

    Пример: "['./app/images/svg-sprite/*.svg']".
     */
    Object.defineProperty(_Self, 'InSvgSpriteCompilePaths', {
        get: function () {
            var list = [
                _Self.InSvgSprite + '*.svg'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей
    к файлам стилей в шаблонах (templates) в исходной директории.

    Пример: "['./app/templates/ ** /*.scss']".
     */
    Object.defineProperty(_Self, 'InScssTemplatesPaths', {
        get: function () {
            var list = [
                _Self.InTemplates + '**/*.scss',
                _Self.InTemplatesLib + '**/*.scss'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей для слежения
    за js-файлами в исходной директории.

    Пример: "['./app/js/*.js']".
     */
    Object.defineProperty(_Self, 'InJsWatchPaths', {
        get: function () {
            var list = [
                _Self.InJs + '*.js',
                _Self.InTemplates + '**/*.js'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей для слежения
    за файлами стилей в исходной директории.

    Пример: "['./app/scss/*.scss']".
     */
    Object.defineProperty(_Self, 'InScssWatchPaths', {
        get: function () {
            var list = [
                _Self.InScss + '*.scss',
                _Self.InScss + '*.css',
                _Self.InScssBase + '*.scss'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей для слежения
    за файлами стилей в шаблонах (templates) в исходной директории.

    Пример: "['./app/templates/ ** /*.scss']".
     */
    Object.defineProperty(_Self, 'InScssTemplatesWatchPaths', {
        get: function () {
            var list = [
                _Self.InTemplates + '**/*.scss',
                _Self.InTemplatesLib + '**/*.scss'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей для слежения
    за pug-файлами в исходной директории.

    Пример: "['./app/*.pug']".
     */
    Object.defineProperty(_Self, 'InPugWatchPaths', {
        get: function () {
            var list = [
                _Self.In + '*.pug',
                _Self.InPug + '*.pug',
                _Self.InPug + '**/*.pug',
                _Self.InTemplates + '*.pug',
                _Self.InTemplates + '**/*.pug',
                _Self.InTemplatesLib + '*.pug',
                _Self.InTemplatesLib + '**/*.pug'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей для слежения
    за файлами шрифтов в исходной директории.

    Пример: "['./app/fonts/*']".
     */
    Object.defineProperty(_Self, 'InFotnsWatchPaths', {
        get: function () {
            var list = [
                _Self.InFonts + '*',
                _Self.InFonts + '**/*'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей для слежения
    за файлами картинок в исходной директории.

    Пример: "['./app/images/*.*']".
     */
    Object.defineProperty(_Self, 'InImagesWatchPaths', {
        get: function () {
            var list = [
                _Self.InImages + '*.*'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей для слежения
    за файлами спрайтов в исходной директории.

    Пример: "['./app/images/sprite/*.*']".
     */
    Object.defineProperty(_Self, 'InSpriteWatchPaths', {
        get: function () {
            var list = [
                _Self.InSprite + '*.*'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей для слежения
    за файлами картинок для контента в исходной директории.

    Пример: "['./app/pictures/*.*']".
     */
    Object.defineProperty(_Self, 'InPicturesWatchPaths', {
        get: function () {
            var list = [
                _Self.InPictures + '*.*'
            ];

            return list;
        }
    });
    //...................................
    /*
    Содержит массив путей на основе файла ./ss-gulp/conf/options.json
    к js-файлам, которые нужно документировать в исходной директории.

    Пример: "['./app/js/*.js']".
     */
    Object.defineProperty(_Self, 'InDocJsPaths', {
        get: function () {
            var list = [];
            if (!_Options.DocFiles) return list;

            _Options.DocFiles.forEach(function (Item) {
                list.push(_Self.InJs + Item + '.js');
            });

            return list;
        }
    });
    //...................................
    // /PROPERTIES
    //--------------------------------------------
    init();
    //--------------------------------------------
}
// /CODE
//-----------------------------------------------------
// EXPORT
module.exports = new CUri();
//...........................................
// /EXPORT
//-----------------------------------------------------
