/// <binding />
const gulp = require('gulp');
const concat = require('gulp-concat');
const bs = require('browser-sync').create();
const uglifyjs = require('gulp-uglify-es').default;
const uglifycss = require('gulp-uglifycss');


const cshtml = [
    "Views/*/*.cshtml",
    "Views/*/*/*.cshtml"
];


const vendorStyles = [
    "wwwroot/lib/bootstrap/dist/css/bootstrap.css",
    "node_modules/bootstrap-datepicker/dist/css/bootstrap-datepicker.css",
    "node_modules/select2/dist/css/select2.css",
    "node_modules/datatables.net-bs/css/dataTables.bootstrap.css",
    "node_modules/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css",
    "node_modules/bootstrap-daterangepicker/daterangepicker.css",
    "node_modules/sweetalert2/dist/sweetalert2.min.css",
    "node_modules/spin.js/spin.css",
    "node_modules/bs-stepper/dist/css/bs-stepper.css",
   
    "wwwroot/lib/font-awesome/css/font-awesome.css",
    "wwwroot/lib/adminlte/css/AdminLTE.css",
    "wwwroot/lib/adminlte/css/skins/_all-skins.css",
    "wwwroot/css/site.css"
];
const vendorScripts = [
    "node_modules/jquery/dist/jquery.js",
    "node_modules/popper.js/dist/umd/popper.js",
    "wwwroot/lib/bootstrap/dist/js/bootstrap.js",
    "node_modules/moment/moment.js",
    "node_modules/bootstrap-datepicker/dist/js/bootstrap-datepicker.js",
    "node_modules/datatables.net/js/jquery.dataTables.js",
    "node_modules/datatables.net-bs/js/dataTables.bootstrap.js",
    "node_modules/datatables.net-fixedheader-bs/js/dfixedHeader.bootstrap.min.js",
    "node_modules/bootstrap-daterangepicker/daterangepicker.js",
    "node_modules/select2/dist/js/select2.full.js",
    "node_modules/sweetalert2/dist/sweetalert2.all.min.js",
    "node_modules/spin.js/spin.js",
    "node_modules/bs-stepper/dist/js/bs-stepper.js",
    "node_modules/chart.js/dist/Chart.js",

    "wwwroot/lib/adminlte/js/adminlte.js",
    "wwwroot/js/*.js"
];

gulp.task('build-vendor-css', () => {
    return gulp.src(vendorStyles)
        .pipe(uglifycss())
        .pipe(concat('vendor.min.css'))
        .pipe(gulp.dest('wwwroot')) 
        .pipe(bs.stream());
});

gulp.task('build-vendor-js', () => {
    return gulp.src(vendorScripts)
        .pipe(uglifyjs())
        .pipe(concat('vendor.min.js'))
        .pipe(gulp.dest('wwwroot'))
        .pipe(bs.stream());

});


gulp.task('watch', ['browser-sync'], function () {
    gulp.watch('wwwroot/js/*.js', ['build-vendor-js']);
    gulp.watch('wwwroot/css/site.css', ['build-vendor-css']);
    bs.watch("wwwroot/*.css").on("change", bs.reload);
    bs.watch(cshtml).on("change", bs.reload);
    bs.watch('wwwroot/*.js').on("change", bs.reload)
});

gulp.task('browser-sync', function () {
    bs.init({
        proxy: {
            target: 'localhost:57836', // IIS express port
            ws:true
        },
        notify: true
    });
});


gulp.task('build-vendor', ['build-vendor-css', 'build-vendor-js']);

gulp.task('default', ['browser-sync','build-vendor','watch']);