//-----------------------------------------------------
// REQUIRE
var Gulp = require('gulp');
var Conf = require('./conf');
// /REQUIRE
//-----------------------------------------------------
// CODE
var Lib = {
    watch: function (Path, Tasks) {
        Tasks = (Array.isArray(Tasks)) ? Tasks : [Tasks];
        Gulp.watch(Path, Gulp.series.apply(this, Tasks));
    }
}
//...........................................
// /CODE
//-----------------------------------------------------
// EXPORT
module.exports = Lib;
//...........................................
// /EXPORT
//-----------------------------------------------------
