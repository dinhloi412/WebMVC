var cart = {
    init: function () {
        cart.regEvents();

    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cardList = [];
            $.each(listProduct, function (I, item) {
                cardList.push(
                    {
                        Quantity: $(item).val(),
                        Product: {
                        ID:$(item).data('id')
                        }
                    });
            });
            $.ajax(
                {
                    url: '/Cart/Update',
                    data: { cartModel: JSON.stringify(cardList) },
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/gio-hang";
                        }
                        
                    }
                }
                    )

        });
    }
}
cart.init();