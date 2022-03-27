jQuery.fn.ssAjaxForm = function (UserConf) {
    var $ = jQuery;
    var Self = this;

    var Conf = {
        NotEmptyCss: '.dcj-not-empty',
        ValidNotEmpty: true,
        ErrorsCss: '.dcj-errors-wrapper',
        ShowErrors: true,
        AnswerCss: '.dcj-answer-wrapper',
        ShowAnswer: true,
        TimeBan: true,
        TimeBanDelay: 3000,

        onBeforeSend: function (Data) {},
        onAfterSend: function (Data) {},
        onValidError: function (Data) {},
        onBanError: function (Data) {}
    };

    $.extend(Conf, UserConf);

    return this.each(function () {
        // PRIVATE FIELDS
        var Item = this;
        Item.dc = {};
        var Ds = Item.ds;
        var $Item = $(Item);
        var _Ban = false;
        // /PRIVATE FIELDS
        //--------------------------------------------
        // PUBLIC FIELDS
        // /PUBLIC FIELDS
        //--------------------------------------------
        // INIT
        function init () {
            setVars();
            setEvents();
        }
        //...................................
        function setVars () {}
        //...................................
        function setEvents () {
            $Item.on('submit', onSubmit);
        }
        //...................................
        // /INIT
        //--------------------------------------------
        // PUBLIC
        Ds.send = function () {
            var valid = Ds.valid();
            var result = (valid.result) ? true : onNotValid(valid);
            if (!result) return;
            if (onBeforeSend() === false) return;

            Ds.SendAction(Dc.Action, Dc.FormData, onAnswer);
        };
        //...................................
        Dc.valid = function () {
            var result = {
                result: true
            };

            if (Conf.ValidNotEmpty) {
                var empty_result = validEmptyFields();
                result.result = (!empty_result.result) ? false : result.result;
                result.empty_result = empty_result;
            }

            return result;
        }
        // /PUBLIC
        //--------------------------------------------
        // EVENTS
        function onSubmit () {
            if (Conf.ShowErrors) Dc.$Errors.hide();
            if (Conf.ShowAnswer) Dc.$Answer.hide();

            Dc.send();
            return false;
        }
        //...................................
        function onAnswer (Msg) {
            var result = doUserEvent('onAfterSend', Msg);
            if (Conf.ShowAnswer) Dc.$Answer.show();

            return result;
        }
        //...................................
        function onNotValid (Valid) {
            var result = doUserEvent('onValidError', Valid);
            if (!result && Conf.ShowErrors) Dc.$Errors.show();

            return result;
        }
        //...................................
        function onBeforeSend () {
            if (Dc.Ban) return onBanError();

            Dc.Ban = true;

            return doUserEvent('onBeforeSend');
        }
        //...................................
        function onBanError () {
            return !!doUserEvent('onBanError');
        }
        //...................................
        function onBanDelay () {
            Ds.Ban = false;
        }
        //...................................
        // /EVENTS
        //--------------------------------------------
        // PRIVATE
        function doUserEvent (Name, Data) {
            if (typeof(Conf[Name]) == 'function') return Conf[Name](Data);
        }
        //...................................
        function validEmptyFields () {
            var result = {
                result: true,
                fields: []
            };

            Ss.$NotEmptyFields.each(function () {
                var $this = $(this);
                var type = $this.attr('type');

                switch (type) {
                    case 'checkbox':
                        if (!$this.is(':checked')) result.fields.push($this);
                        break;
                    default:
                        if (!$this.val().trim()) result.fields.push($this);
                }
            });

            if (result.fields.length) result.result = false;

            return result;
        }
        //...................................
        // /PRIVATE
        //--------------------------------------------
        // PROPERTIES
        Object.defineProperty(Dc, 'Method', {
            get: function () {
                return $Item.attr('method');
            }
        });
        //...................................
        Object.defineProperty(Dc, 'SendAction', {
            get: function () {
                switch (Dc.Method) {
                    case 'post': return $.post;
                    case 'get': return $.get;
                    default: return $.post;
                }
            }
        });
        //...................................
        Object.defineProperty(Dc, 'Action', {
            get: function () {
                return $Item.attr('action');
            }
        });
        //...................................
        Object.defineProperty(Dc, 'FormData', {
            get: function () {
                return $Item.serialize();
            }
        });
        //...................................
        Object.defineProperty(Dc, '$NotEmptyFields', {
            get: function () {
                return $Item.find(Conf.NotEmptyCss);
            }
        });
        //...................................
        Object.defineProperty(Dc, '$Answer', {
            get: function () {
                return $Item.find(Conf.AnswerCss);
            }
        });
        //...................................
        Object.defineProperty(Dc, '$Errors', {
            get: function () {
                return $Item.find(Conf.ErrorsCss);
            }
        });
        //...................................
        Object.defineProperty(Dc, 'Ban', {
            set: function (Value) {
                if (!Conf.TimeBan) return;
                if (Value) setTimeout(onBanDelay, Conf.TimeBanDelay);

                _Ban = Value;
            },

            get: function () {
                return _Ban;
            }
        });
        // /PROPERTIES
        //--------------------------------------------
        init();
        //--------------------------------------------
    });
};
