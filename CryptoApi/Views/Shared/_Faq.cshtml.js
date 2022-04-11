// faq
jQuery('.dc-faq').dcTpl(function ($, Export) {
   var $self = $(this);
});

//faq hide/open answers
document.querySelectorAll('.dc-faq').forEach((faq) => {
    document.querySelectorAll('.dc-faq-item').forEach((main) => {
        
        function isAnswerOpened(answer) {
            return answer.style.display != 'none';
        }
        function toggle(main) {
            let answer = main.parentNode.querySelector('.dc-faq-item__content');
            let toggle_view = main.querySelector('.dcg-btn .dcg-toggle_view');
            let toggle_hide = main.querySelector('.dcg-btn .dcg-toggle_hide');

            answer.style.display = isAnswerOpened(answer) ? 'none' : 'block';
            toggle_view.style.display = isAnswerOpened(answer) ? 'none' : 'inline-block';
            toggle_hide.style.display = isAnswerOpened(answer) ? 'inline-block' : 'none';
        }
        main.addEventListener('click', function (e) {
            toggle(main);
        })
    });
});


// /faq
//--------------------------------------------
