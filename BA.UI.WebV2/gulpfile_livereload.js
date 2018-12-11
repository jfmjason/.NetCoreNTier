/// <binding AfterBuild='watch' />
const gulp = require('gulp');
const concat = require('gulp-concat');
const connect = require('gulp-connect');
var livereload = require('gulp-livereload');
var csssource = ['wwwroot/*.css'];


const vendorStyles = [
    "node_modules/bootstrap/dist/css/bootstrap.css",
    "node_modules/bootstrap-datepicker/dist/css/bootstrap-datepicker.css",
    "node_modules/select2/dist/css/select2.css",
    "node_modules/datatables.net-bs/css/dataTables.bootstrap.css",
    "node_modules/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css",
    "node_modules/bootstrap-daterangepicker/daterangepicker.css",
    "node_modules/sweetalert2/dist/sweetalert2.min.css",
    "node_modules/spin.js/spin.css",

    "wwwroot/lib/font-awesome/css/font-awesome.css",
    "wwwroot/lib/adminlte/css/AdminLTE.css",
    "wwwroot/lib/adminlte/css/skins/_all-skins.css",
    "wwwroot/css/site.css"
];
const vendorScripts = [
    "node_modules/jquery/dist/jquery.js",
    "node_modules/popper.js/dist/umd/popper.js",
    "node_modules/bootstrap/dist/js/bootstrap.js",
    "node_modules/moment/moment.js",
    "node_modules/bootstrap-datepicker/dist/js/bootstrap-datepicker.js",
    "node_modules/datatables.net/js/jquery.dataTables.js",
    "node_modules/datatables.net-bs/js/dataTables.bootstrap.js",
    "node_modules/datatables.net-fixedheader-bs/js/dfixedHeader.bootstrap.min.js",
    "node_modules/bootstrap-daterangepicker/daterangepicker.js",
    "node_modules/select2/dist/js/select2.full.js",
    "node_modules/sweetalert2/dist/sweetalert2.all.min.js",
    "node_modules/spin.js/spin.js",

    "wwwroot/lib/adminlte/js/adminlte.js",
    "wwwroot/js/site.js"
];

gulp.task('build-vendor-css', () => {
    return gulp.src(vendorStyles)
        .pipe(concat('vendor.min.css'))
        .pipe(gulp.dest('wwwroot'))
        .pipe(livereload());
});

gulp.task('build-vendor-js', () => {
    return gulp.src(vendorScripts)
        .pipe(concat('vendor.min.js'))
        .pipe(gulp.dest('wwwroot'));
});


gulp.task('watch', function () {
    livereload.listen();
    gulp.watch('wwwroot/js/site.js', ['build-vendor-js']).on('change', livereload.changed);
    gulp.watch('wwwroot/css/site.css', ['build-vendor-css']).on('change', livereload.changed);
    gulp.watch('*.css').on('change', livereload.changed);
});


gulp.task('connect', function () {
    connect.server({
        root: '.',
        //https: true,
        livereload: {
            enable: true,
            port: 57836
        },
        debug: true
    })
});



gulp.task('build-vendor', ['build-vendor-css', 'build-vendor-js']);

gulp.task('default', ['build-vendor']);