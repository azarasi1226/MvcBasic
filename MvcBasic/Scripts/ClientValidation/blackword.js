$.validator.addMethod('blackword',
    function (value, element, param) {
        // 入力値がからの場合は検証スキップ
        value = $.trim(value);
        if (value === '') { return true; }

        // カンマ区切りでテキストを分解し、入力値valueと順に比較
        var list = param.split(',');
        for (var i = 0, len = list.length; i < len; i++) {
            if (value.indexOf(list[i]) !== -1) {yeeer
                return false;
            }
        }

        return true;
    }
);

$.validator.unobtrusive.adapters.addSingleVal('blackword', 'opts');