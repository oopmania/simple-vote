const gulp = require('gulp');
const clean = require('gulp-clean');
const concat = require('gulp-concat');

const paths = {
    libs: {
        src: [
            'node_modules/chart.js/dist/chart.js',
            'node_modules/chartjs-plugin-datalabels/dist/chartjs-plugin-datalabels.js',
        ],
        dest: 'wwwroot/libs'
    }
};

gulp.task('clean', () => {
    return gulp
        .src(paths.libs.dest, { allowEmpty: true, read: false })
        .pipe(clean());
})

gulp.task('bundle-libs', () => {
    return gulp.src(paths.libs.src)
        .pipe(concat('bundle.js'))
        .pipe(gulp.dest(paths.libs.dest));
});

gulp.task('build', gulp.series('clean', 'bundle-libs'));