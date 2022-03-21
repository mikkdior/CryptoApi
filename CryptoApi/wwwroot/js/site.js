document.addEventListener('DOMContentLoaded', function () {
    //faq hide/open answers
    document.querySelectorAll('.collapse__btn').forEach((main) => {
        function isAnswerOpened(answer){
            return answer.style.display != 'none';
        }
        function toggle(answer){
            answer.style.display = isAnswerOpened(answer) ? 'none' : 'block';
        }
        main.addEventListener('click', function (e) {
            let answer = main.parentNode.querySelector('.collapse__content');
            toggle(answer);
        })
    });
});
