(function ($) {
    var F = $.dc.f;
    //--------------------------------------------
    // Is JSON
    /**
     * jasdf
     * @memberof dc.f
     * @name isJSON
     * @alias isJSON
     * @function
     * @param  {string} Value asdfl;kj
     * @return {bool}       adflk;j
     */
    F.isJSON = function (Value) {
        try {
            return $.parseJSON(Value);
        }
        catch(err) {
            return false;
        }
    };
    // /Is JSON
    //--------------------------------------------
    // arrayUnique - удаляет из массива одинаковые значения
    F.arrayUnique = function (array) {
        var a = array.concat();
        for(var i=0; i<a.length; ++i) {
            for(var j=i+1; j<a.length; ++j) {
                if(a[i] === a[j])
                    a.splice(j--, 1);
            }
        }

        return a;
    }
    // /arrayUnique
    //--------------------------------------------
    // Сравнивает два массива. Если Sort = true - перед сравнением производится сортировка.
    F.arrayEquals = function (Array1, Array2, Sort, Lowcase) {
        if (Array1.length !== Array2.length) return false;

        if (Lowcase) {
            Array1 = F.arrayToLowerCase(Array1);
            Array2 = F.arrayToLowerCase(Array2);
        }

        if (Sort) {
            Array1 = Array1.sort();
            Array2 = Array2.sort();
        }

        var result = true;

        Array1.forEach(function (Value, Index) {
            if (Value !== Array2[Index]) result = false;
        });

        return result;
    }
    //--------------------------------------------
    // Обрезает пробелы по краям каждого элемента массива
    F.arrayTrim = function (List) {
        for (var i in List) {
            List[i] = String(List[i]).trim();
        }

        return List;
    }
    //--------------------------------------------
    // Приводит все элементы массива в нижний регистр
    F.arrayToLowerCase = function (List) {
        for (var i in List) {
            List[i] = String(List[i]).toLowerCase();
        }

        return List;
    }
    //--------------------------------------------
    // Приводит все элементы массива в верхний регистр
    F.arrayToUpperCase = function (List) {
        for (var i in List) {
            List[i] = String(List[i]).toUpperCase();
        }

        return List;
    }
    //--------------------------------------------
    F.getArgs = function (Args, Shift) {
        Shift = Shift ? Shift : 0;
        var args = Array.from(Args);

        while(Shift-- > 0) args.shift()

        return args;
    }
    //--------------------------------------------
})(jQuery);
