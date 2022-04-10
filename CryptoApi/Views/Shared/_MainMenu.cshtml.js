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

/*document.querySelectorAll('.dc-main-menu').forEach((main) => {
    let hamburger_open = main.querySelector('.dc-main-menu__hamburger-open');
    let hamburger_close = main.querySelector('.dc-main-menu__hamburger-close');
    let nav = main.querySelector('.nav');

    hamburger_open.addEventListener('click', function (e) {
        hamburger_open.style.display = 'none';
        hamburger_close.style.display = 'inline-block';
        nav.display = 'flex';
        main.style.boxShadow = '0px 10px 30px 0px #2125291F';
    });

    hamburger_close.addEventListener('click', function (e) {
        hamburger_close.style.display = 'none';
        hamburger_open.style.display = 'inline-block';
        nav.style.display = 'none';
        main.style.boxShadow = 'unset';
    });
});*/
    

// /main-menu
//--------------------------------------------
