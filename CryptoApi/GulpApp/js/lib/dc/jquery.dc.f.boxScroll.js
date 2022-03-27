jQuery.dc.f.boxScroll = function (Box, UserConf) {
    var $ = jQuery;

    var Conf = {
        topShift: 0,

        callback: function () {}
    };

    $.extend(Conf, UserConf);

    this.ready.prototype.dc = (this.ready.prototype.dc) ? this.ready.prototype.dc : {};
    var Static = this.ready.prototype.dc;
    Static.Items = (Static.Items) ? Static.Items : [];
    var Items = Static.Items;

    Items.push({
        box: Box,
        callback: Conf.callback,
        view: false
    });

    function check () {}

    $(window).scroll(function () {
        var win_height = $(window).height();
        var scroll = $(window).scrollTop();

        $.each(Items, function () {
            var item = this;
            var $box = $(item.box);
            var height = $box.height();
            var top = $box.offset().top + Conf.topShift;

            if ((scroll + win_height) >= top) {
                if (item.view) return;

                item.callback.call($box);

                item.view = true;
            } else {
                item.view = false;
            }
        });
    });
};
