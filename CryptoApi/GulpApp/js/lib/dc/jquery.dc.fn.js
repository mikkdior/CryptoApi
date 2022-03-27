/**
 * @module jQueryPlugins
 */
(function ($) {
    // Плагин связывает атрибуты элемента с аргументами плагина
    // Атрибут должен иметь следующий формат:
    // data-<plugin_name>="arg_name_1: val_1; arg_name_2: val_2"
    $.fn.dcLink = function (Func, Attr) {
        var $This = $(this);

        return $This.each(function () {
            var $this = $(this);
            var data = $this.data(Func.toLowerCase()) || '';
            var attr = Attr || {};
            data = data.split(';');

            for (var i in data) {
                if (!data[i]) continue;

                var info = data[i].split(':');
                var key = info[0].trim();
                var value = info[1].trim();

                attr[key] = value;
            }

            $this[Func](attr);
        });
    };
    //--------------------------------------------
})(jQuery);
