var user = {
    init: function () {
        user.registerEvets();
    },
    registerEvets: function (){
        $('.btn-active').off('click').on('click', function (e){
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/changeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
               
                success: function (response) {
                    if (response.status == true) {
                        btn.text("kích hoạt");
                    }
                    else {
                        btn.text("Khoá");
                    }

                }

            });
        });

    }
}
user.init();