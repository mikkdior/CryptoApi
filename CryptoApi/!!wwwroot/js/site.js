document.addEventListener('DOMContentLoaded', function () {
    //faq hide/open answers
    document.querySelectorAll('.collapse__btn').forEach((main) => {
        let answer = main.parentNode.querySelector('.collapse__content');
        answer.style.display = 'none';

        function isAnswerOpened(answer){
            return answer.style.display != 'none';
        }
        function toggle(main) {
            let answer = main.parentNode.querySelector('.collapse__content');
            let arrow = main.querySelector('.dc-faq-btn');
            answer.style.display = isAnswerOpened(answer) ? 'none' : 'block';
            arrow.style.transform = isAnswerOpened(answer) ? 'rotate(90deg)' : 'rotate(0deg)';
        }
        main.addEventListener('click', function (e) {
            toggle(main);
        })
    });
});
