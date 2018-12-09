$(function () {

    new WOW().init();

    // start menu responsive

    $('.header__menu').on('click', function (event) {
        event.stopPropagation();
        $('.sidebar').addClass('toggled');
        $('body').addClass('aside-toggled');
    })

    $('.sidebar').on('click', function (event) {
        event.stopPropagation();
    })

    $(window).click(function (event) {
        $('.sidebar').removeClass('toggled');
        $('body').removeClass('aside-toggled');
    });

    // end menu responsive

    $(window).scroll(function () {
        if ($(this).scrollTop() > 30) {
            $('.header').addClass('header--scrolled');
        } else {
            $('.header').removeClass('header--scrolled');
        }
    })

    // show / hide sub menu

    $('.sidebar__navigation__item').on('click', function (event) {
        event.stopPropagation();
        //var active = $(this).find('.sidebar__navigation__item__link').addClass('active');
        var subMenu = $(this).find('ul.sidebar__navigation-sub').slideToggle();
    })

    // show / hide sub menu

    // scroll bar 

    $(".scroll-panel").mCustomScrollbar({
        scrollButtons: {
            enable: true,
            scrollType: "stepped"
        },
        keyboard: {
            scrollType: "stepped"
        },
        mouseWheel: {
            scrollAmount: 188,
            normalizeDelta: true
        },
        theme: "rounded-dark",
        autoExpandScrollbar: true,
        snapAmount: 188,
        snapOffset: 65

    });

    // seperator 

    // seperator 
    function seperator(x) {
        var sep = x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        console.log(sep);
        return sep;
    }

    $('.seperator').each(function (index, el) {
        $(el).text(seperator(el.innerText));
    })

    // amchart js 

    var chart = AmCharts.makeChart("chartdiv", {
        "type": "serial",
        "theme": "dark",
        "dataDateFormat": "YYYY-MM-DD",
        "dataProvider": [{
            "date": "2013-11-30",
            "value": 104
        }, {
            "date": "2013-12-01",
            "value": 108
        }, {
            "date": "2013-12-02",
            "value": 103
        }, {
            "date": "2013-12-03",
            "value": 105
        }, {
            "date": "2013-12-04",
            "value": 136
        }, {
            "date": "2013-12-05",
            "value": 138
        }, {
            "date": "2013-12-06",
            "value": 113
        }, {
            "date": "2013-12-07",
            "value": 131
        }, {
            "date": "2013-12-08",
            "value": 114
        }, {
            "date": "2013-12-09",
            "value": 124
        }],
        "valueAxes": [{
            "maximum": 140,
            "minimum": 100,
            "axisAlpha": 0,
            "guides": [{
                "fillAlpha": 0.1,
                "fillColor": "#CC0000",
                "lineAlpha": 0,
                "toValue": 120,
                "value": 0
            }, {
                "fillAlpha": 0.1,
                "fillColor": "#0000cc",
                "lineAlpha": 0,
                "toValue": 200,
                "value": 120
            }]
        }],
        "graphs": [{
            "bullet": "round",
            "dashLength": 4,
            "valueField": "value"
        }],
        "chartCursor": {
            "cursorAlpha": 0,
            "zoomable": false,
            "valueZoomable": true
        },
        "categoryField": "date",
        "categoryAxis": {
            "parseDates": true
        },
        "valueScrollbar": {

        }
    });

    // amcart clock 

    var chart;
    var sArrow;
    var mArrow;
    var hArrow;

    AmCharts.ready(function () {

        // clock is just an angular gauge with three arrows
        chart = new AmCharts.AmAngularGauge();
        chart.startDuration = 0.3;

        // for simplicyty, we use only one axis
        var axis = new AmCharts.GaugeAxis();
        axis.startValue = 0;
        axis.endValue = 12;
        axis.valueInterval = 1;
        axis.minorTickInterval = 0.2;
        axis.showFirstLabel = false;
        axis.startAngle = 0;
        axis.endAngle = 360;
        axis.axisAlpha = 0.3;
        chart.addAxis(axis);

        // hour arrow
        hArrow = new AmCharts.GaugeArrow();
        hArrow.radius = "50%";
        hArrow.clockWiseOnly = true;

        // minutes arrow
        mArrow = new AmCharts.GaugeArrow();
        mArrow.radius = "80%";
        mArrow.startWidth = 6;
        mArrow.nailRadius = 0;
        mArrow.clockWiseOnly = true;

        // seconds arrow
        sArrow = new AmCharts.GaugeArrow();
        sArrow.radius = "90%";
        sArrow.startWidth = 3;
        sArrow.nailRadius = 4;
        sArrow.color = "#CC0000";
        sArrow.clockWiseOnly = true;

        // update clock before adding arrows to avoid initial animation
        updateClock();

        // add arrows
        chart.addArrow(hArrow);
        chart.addArrow(mArrow);
        chart.addArrow(sArrow);

        chart.write("chartdivClock");

        // update each second
        setInterval(updateClock, 1000);
    });

    // update clock
    function updateClock() {
        // get current date
        var date = new Date();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var seconds = date.getSeconds();

        // set hours
        hArrow.setValue(hours + minutes / 60);
        // set minutes
        mArrow.setValue(12 * (minutes + seconds / 60) / 60);
        // set seconds
        sArrow.setValue(12 * date.getSeconds() / 60);
    }

    $('.grid').isotope({
        // set itemSelector so .grid-sizer is not used in layout
        itemSelector: '.grid__item',
        originLeft: false,
        
    })

    $('.fancybox').fancybox();

    $('[data-role="sweet"]').on('click',function(){
        swal({
            title: 'حذف آیتم ',
            text: "ایا مطمئن هستید ؟؟",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#28a745',
            cancelButtonColor: '#d33',
            confirmButtonText: 'بله حذف کن ',
            cancelButtonText: 'نه منصرف شدم '
          }).then(function(result) {
            if (result.value) {
              swal(
                'حذف شد ',
                'عملیات با موفقیت انجام شد',
                'success'
              )
            }
          })
    })

    // toastr.options.closeButton = true;
    // toastr.options.newestOnTop = false;
    //toastr.options.progressBar = true;
    toastr.options.rtl = true

    $('[data-role="toaster"]').on('click',function(){
        toastr.warning('در وارد کردن اطلاغات دقت کنید ');
        toastr.error('در وارد کردن اطلاغات دقت کنید ');
        toastr.success('عملیات با موفقیت انجام شد  ');
    })

    $('[data-fancybox]').fancybox({
        iframe: {
            css: {
                width: '768px',
                height: '400px'
            }
        }
    });
})