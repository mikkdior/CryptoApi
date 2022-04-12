// faq
jQuery('.dc-faq').dcTpl(function ($, Export) {
    var $self = $(this);

    /*var $coll = $self.find('.dc-faq-item__wrapper');*/
    /* $coll.on('click', function (e) {
        console.log('cllick!!');
    });*/
     
    $self.on('click', '.dc-faq-item__wrapper', function (e) {
        var $item = $(this);
        $item.closest('.dc-faq-item').find('.dc-faq-item__content').stop().slideToggle(); // parent
        $item.toggleClass('dc-faq-item__wrapper_opened');
    });

});

// /faq
//--------------------------------------------
