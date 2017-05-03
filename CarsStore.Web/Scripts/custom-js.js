$(document)
    .ready(function() {
        $(".navbar-default .navbar-nav>li")
            .hover(function(e) {

                var buttonWidth = $(this).width(),
                    buttonPosition = $(this).position(),
                    buttonPositionLeft = buttonPosition.left;

                if ($(this).hasClass('slide-line')) {
                    return;
                }

                $(".slide-line")
                    .css({
                        left: buttonPositionLeft + "px",
                        width: buttonWidth
                    });

            });
    });