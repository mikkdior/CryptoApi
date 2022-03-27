//-----------------------------------------------------
// REQUIRE
var Gulp = require('gulp'),

    // Общие
    Concat = require('gulp-concat'),
    Rename = require('gulp-rename'),
    Plumber = require('gulp-plumber'), // предохраняет от остановки задачи

    // JS
    Uglify = require('gulp-uglify'), // js-минификатор

    // CSS
    Sass = require('gulp-sass'),
    Autoprefixer = require('gulp-autoprefixer'),
    Csso = require('gulp-csso'), // css-минификатор // TODO: не убирает комментарии

    // Images
    SpritesMith = require('gulp.spritesmith'), // генерация спрайтов

    // SS
    Conf = require('./conf'),
    Lib = require('./lib');
    CCreateTemplates = require('./create-templates');
// /REQUIRE
//-----------------------------------------------------
// TASKS
// Компилирует библиотечные файлы стилей
Gulp.task('_css_lib', function (done) {
    Gulp.src(Conf.InAllScssLibPaths)
        .pipe(Concat(Conf.OutCssLibFile))
        .pipe(Sass())
        .pipe(Csso())
        .pipe(Gulp.dest(Conf.OutCss));

    done();
});
//...........................................
// Компилирует js-файлы
Gulp.task('_js_lib', function (done) {
    Gulp.src(Conf.InAllJsLibPaths)
        .pipe(Concat(Conf.OutJsLibFile))
        .pipe(Uglify())
        .pipe(Gulp.dest(Conf.OutJs));

    done();
});
//...........................................
// Компилирует основные js-файлы
Gulp.task('_js', function (done) {
    Gulp.src(Conf.InJsCompilePaths)
        .pipe(Plumber())
        .pipe(Concat(Conf.OutJsFile))
        .pipe(Gulp.dest(Conf.OutJs));

    done();
});
//...........................................
// Объединяет стили шаблонов (templates)
// и записывает в файл scss/_templates.scss
Gulp.task('_scss_templates', function (done) {
    Gulp.src(Conf.InScssTemplatesPaths)
        .pipe(Plumber())
        .pipe(Concat(Conf.InScssTemplatesFile))
        .pipe(Gulp.dest(Conf.InScss));

    done();
});
//...........................................
// Компилирует основные файлы стилей
Gulp.task('_scss', function (done) {
    Gulp.src(Conf.InScssCompilePaths)
        .pipe(Plumber())
        .pipe(Sass())
        //.pipe(Autoprefixer({browsers: ['last 2 versions']}))
        .pipe(Rename(Conf.OutCssFile))
        .pipe(Gulp.dest(Conf.OutCss));

    done();
});
//...........................................
// Создаёт спрайты и стили для них на основе картинок в директории ./app/images/sprite/
Gulp.task('_sprite', function (done) {
    var sprites = Gulp.src(Conf.InSpriteCompilePaths)
        .pipe(Plumber())
        .pipe(SpritesMith({
            imgName: Conf.OutSpriteFile,
            cssName: Conf.InSpriteFile
        }));

    sprites.img.pipe(Gulp.dest(Conf.InImages));
    sprites.css.pipe(Gulp.dest(Conf.InScss));

    done();
});
//...........................................
// Компилирует все библиотечные файлы
Gulp.task('_libs', function (done) {
    Gulp.start(['_css_lib', '_js_lib']);

    done();
});
//...........................................
// Компилирует все файлы
Gulp.task('_compile_all', function (done) {
    Gulp.start(['_sprite', '_libs', '_js', '_scss_templates', '_scss']);

    done();
});
//...........................................
// Запускает слежение за всеми необходимыми файлами
Gulp.task('_watch_all', function (done) {
    Lib.watch(Conf.InJsWatchPaths, ['_js']);
    Lib.watch(Conf.InScssWatchPaths, ['_scss']);
    Lib.watch(Conf.InScssTemplatesWatchPaths, ['_scss_templates']);
    Lib.watch(Conf.InSpriteWatchPaths, ['_sprite']);

    if (Conf.InScssLibOptions.debug || Conf.InComponentsOptions.debug)
        Lib.watch(Conf.InAllScssLibPaths, ['_css_lib']);

    if (Conf.InJsLibOptions.debug || Conf.InComponentsOptions.debug)
        Lib.watch(Conf.InAllJsLibPaths, ['_js_lib']);

    done();
});
//...........................................
// Запускает все процессы для работы
Gulp.task('_default', function (done) {
    Gulp.start(['_watch_all']);
    Gulp.start(['_compile_all']);

    //Gulp.start(['_live_reload']);

    if (Conf.Options.Doc) Gulp.start(['_doc']);

    done();
});
//...........................................
// Создаёт блоки (templates) на основании файла list.struct
Gulp.task('_create_templates', function (done) {
    CreateTemplates = new CCreateTemplates (Conf.InTemplates);
    CreateTemplates.Create();

    done();
});
//...........................................
// /TASKS
//-----------------------------------------------------
// EXPORT
// /EXPORT
//-----------------------------------------------------
