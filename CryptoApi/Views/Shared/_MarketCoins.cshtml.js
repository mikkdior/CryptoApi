// market-coins
jQuery('.dc-market-coins').dcTpl(function ($, Export) {
    var $self = $(this);

    $self.on('click', '.dc-market-coins__sort-by-btn', function (e) {
        var $item = $(this);
        $self.find('.dc-market-coins__sort-by-list').stop().slideToggle(); // parent
    });
});
// /market-coins
//--------------------------------------------
