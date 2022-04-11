// main-menu
jQuery('.dc-main-menu').dcTpl(function ($, Export) {
    var $self = $(this);

    $self.on('click', '.dc-main-menu__hamburger-open', function (e) {
        $self.addClass('dc-main-menu_opened');
        $self.find('.nav').slideDown();
        $(this).css("display", "none");
        $self.find('.dc-main-menu__hamburger-close').css("display", "inline-block");
        e.stopPropagation()
    });
    $self.on('click', '.dc-main-menu__hamburger-close', function (e) {
        $self.find('.nav').slideUp(function () {
            $self.removeClass('dc-main-menu_opened');
        });
        $(this).css("display", "none");
        $self.find('.dc-main-menu__hamburger-open').css("display", "inline-block");
        e.stopPropagation()
    });
    $('body').on('click', function () {
        $self.find('.nav').slideUp(function () {
            $self.removeClass('dc-main-menu_opened');
        });
        $self.find('.dc-main-menu__hamburger-close').css("display", "none");
        $self.find('.dc-main-menu__hamburger-open').css("display", "inline-block");
    });
});

window.matchMedia('(min-width: 992px)').addListener(function (e) {

    if (e.matches) {
        let nav = document.querySelector('.dc-main-menu .nav');
        let button_open = document.querySelector('.dc-main-menu__hamburger-open');
        let button_close = document.querySelector('.dc-main-menu__hamburger-close');
        nav.parentNode.parentNode.classList.remove('dc-main-menu_opened');

        if (nav.style.display == 'none' || nav.style.display == 'block') {
            nav.style.display = 'flex';
        }
        if (button_open.style.display == 'inline-block') {
            button_open.style.display = 'none';
        }
        if (button_close.style.display == 'inline-block') {
            button_close.style.display = 'none';
        }
    }
});
window.matchMedia('(max-width: 992px)').addListener(function (e) {
    if (e.matches) {
        let nav = document.querySelector('.dc-main-menu .nav');
        let button_open = document.querySelector('.dc-main-menu__hamburger-open');
        let button_close = document.querySelector('.dc-main-menu__hamburger-close');

        if (nav.style.display == 'flex') {
            nav.style.display = 'none';
        }
        if (button_open.style.display == 'none') {
            button_open.style.display = 'inline-block';
        }
        if (button_close.style.display == 'none') {
            button_close.style.display = 'none';
        }
    }
});
    

// /main-menu
//--------------------------------------------
