// faq
jQuery('.dc-faq').dcTpl(function ($, Export) {
    var $self = $(this);

    var $coll = $self.find('.dc-faq-item__wrapper');

    /* $coll.on('click', function (e) {
        console.log('cllick!!');
    });*/

    $self.on('click', '.dc-faq-item__wrapper', function (e) {
        console.log('cllick!!');
        var $item = $(this);
        $item.closest('.dc-faq-item').find('.dc-faq-item__content').stop().slideToggle(); // parent
        $item.toggleClass('.dc-faq-item__wrapper_opened');
    });

});

/*//faq hide/open answers
document.querySelectorAll('.dc-faq').forEach((faq) => {
    document.querySelectorAll('.dc-faq-item').forEach((main) => {

        let answer = main.parentNode.querySelector('.dc-faq-item__content');
        let toggle_view = main.querySelector('.dcg-btn .dcg-toggle_view');
        let toggle_hide = main.querySelector('.dcg-btn .dcg-toggle_hide');

        if (main == faq.children[0]) {
            toggle_view.style.display = 'none';
            toggle_hide.style.display = 'inline-block';
            answer.style.display = 'inline-block';
        }
        else {
            toggle_view.style.display = 'inline-block';
            toggle_hide.style.display = 'none';
            answer.style.display = 'none';
        }

        main.querySelector('.dc-faq-item__wrapper').addEventListener('click', function (e) {

            var IsPlus = toggle_view.style.display == 'inline-block';

            if (IsPlus) {
                toggle_view.style.display = 'inline-block';
                answer.style.display = 'none';
                toggle_hide.style.display = 'none';
            }
            else {
                toggle_view.style.display = 'none';
                answer.style.display = 'inline-block';
                toggle_hide.style.display = 'inline-block';
            }
            
        })
    });
});*/


// /faq
//--------------------------------------------
