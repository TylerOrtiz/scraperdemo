const { series, parallel, src, dest } = require('gulp');
var del = require('del');

function clean() {
    return del([
        './wwwroot/dist',
        './wwwroot/js'
    ]);
}

function bootstrapJs() {
    return src('./node_modules/bootstrap/dist/**/*.js')
        .pipe(dest('./wwwroot/dist/bootstrap'));
}

function bootstrapCss() {
    return src('./node_modules/bootstrap/dist/**/*.css')
        .pipe(dest('./wwwroot/dist/bootstrap'));
}

bootstrapTask = parallel(bootstrapJs, bootstrapCss);

function jQuery() {
    return src('./node_modules/jquery/dist/**/*.js')
        .pipe(dest('./wwwroot/dist/jquery'));
}

function popperJs() {
    return src('./node_modules/popper.js/dist/**/*.js')
        .pipe(dest('./wwwroot/dist/popper'));
}

function appScripts() {
    return src('./Scripts/**/*.js').pipe(dest('./wwwroot/js'));
}

buildTask = series(bootstrapTask, jQuery, popperJs, appScripts);
cleanTask = series(clean);

exports.build = buildTask;
exports.clean = cleanTask;
exports.default = series(cleanTask, buildTask);
