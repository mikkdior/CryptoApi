var Gulp = require('gulp');
var Tasks = require('./ssGulp/tasks');

//...........................................
Gulp.start = function (task_names) {
    task_names = (Array.isArray(task_names)) ? task_names : [task_names];
    var func = Gulp.series.apply(this, task_names);
    func();
}
//...........................................
// Запускает все процессы для работы
Gulp.task('default', function (done) {
    Gulp.start('_default');
    done();
});
//...........................................
// Создаёт блоки (templates) на основании файла list.struct
Gulp.task('create_templates', function (done) {
    Gulp.start('_create_templates');
    done();
});
//...........................................

