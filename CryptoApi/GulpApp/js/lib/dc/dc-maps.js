jQuery(function ($) {
    if (!$.dc) $.dc = {};
    if (!$.dc.maps) $.dc.maps = {};
    var Maps = $.dc.maps;
    Maps.onReady = function () {};
    if (typeof(ymaps) == 'undefined') return;

    Maps.onReady = ymaps.ready;
    //--------------------------------------------
    // Инициализация
    ymaps.ready(function () {
        Maps.ready = true;
    });
    //--------------------------------------------
    // Создание карты
    Maps.create = function (id, center = [55.76, 37.64]) {
        return new ymaps.Map(id, {
            center: center,
            controls: ['fullscreenControl'],
            zoom: 7
        });
    };
    //--------------------------------------------
    // Создание точки
    Maps.addPoint = function (map, coords, map_to_center = false, drag = false, drag_callback) {
        var placemark = new ymaps.Placemark(coords, null, {
            draggable: drag
        });

        placemark.events.add('dragend', drag_callback, placemark);
        map.geoObjects.add(placemark);

        if (map_to_center) {
            map.setCenter(coords, 18);
            //map.setBounds(coords, {
            //    checkZoomRange: true
            //});
        }

        return placemark;
    };
    //--------------------------------------------
    // Создание точки
    Maps.addPoints = function (map, coords, callback) {
        if (!coords) return;

        var points = new ymaps.GeoObjectCollection();

        coords.forEach(function (item) {
            var placemark = new ymaps.Placemark(item.coords, {
                'card_id': item.id
            });
            placemark.events.add('click', callback);
            points.add(placemark);
        });

        map.geoObjects.add(points);

        map.setBounds(points.getBounds(), {
            checkZoomRange: true,
        });

        map.setZoom(map.getZoom());
    };
    //--------------------------------------------
    // Удаление всех точек
    Maps.clearPoints = function (map) {
        map.geoObjects.each(function (geoObject) {
            map.geoObjects.remove(geoObject);
        });
    };
    //--------------------------------------------
    // Узнать адрес по координатам
    Maps.getAddress = function (coords, callback) {
        ymaps.geocode(coords).then(function(res) {
            var data = res.geoObjects.get(0).properties.getAll();

            if (callback) callback(data.text, data);
        });
    };
    //--------------------------------------------
    // Поиск вариантов адреса для автозаполнения
    Maps.searchAddress = function (word, callback) {
        ymaps.suggest(word).then(callback);
    };
    //--------------------------------------------
    // Координаты адреса
    Maps.getCoord = function (address, callback) {
        var geocode = ymaps.geocode(address);

        geocode.then(function (res) {
            var position = res.geoObjects.get(0).geometry.getCoordinates();
            if (callback) callback(position);
        });
    };
    //--------------------------------------------
});
