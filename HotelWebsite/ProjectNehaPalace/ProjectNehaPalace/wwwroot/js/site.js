// Write your JavaScript code.

//Pagination Script

//$(".next").click(function () {
//    var target = $(".nav-tabs li.active");
//    var sibbling;
//    if ($(this).text() === "Next") {
//        sibbling = target.next();
//    } else {
//        sibbling = target.prev();
//    }
//    if (sibbling.is("li")) {
//        sibbling.children("a").tab("show");
//    }
//});

//$(".previous").click(function () {
//    var target = $(".nav-tabs li.active");
//    var sibbling;
//    if ($(this).text() === "Previous") {
//        sibbling = target.prev();
//    } else {
//        sibbling = target.next();
//    }
//    if (sibbling.is("li")) {
//        sibbling.children("a").tab("show");
//    }
//});



//$("#PaymentBtn").click(function () {
//    var target = $(".nav-tabs li.active");
//    var sibbling;
//    if ($(this).val() === "Submit") {
//        sibbling = target.next();
//    } 
//    if (sibbling.is("li")) {
//        sibbling.children("a").tab("show");
//    }
//    });

$(document).ready(function () {
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
        localStorage.setItem('activeTab', $(e.target).attr('href'));
    });
    var activeTab = localStorage.getItem('activeTab');
    if (activeTab) {
        $('#booking-tabs a[href="' + activeTab + '"]').tab('show');
    }

    //$("#tab2").addClass('disabled');
    //$("#tab2 a").removeAttr('data-toggle');

    //$("#tab3").addClass('disabled');
    //$("#tab3 a").removeAttr('data-toggle');

    //$("#tab4").addClass('disabled');
    //$("#tab4 a").removeAttr('data-toggle');

    

});



$(function () {

    //$('#next1').click(function (e) {
    //    e.preventDefault();
    //    $("#saveDateForm").submit();
    //    $('#booking-tabs a[href="#booking-choose-room"]').tab('show');
    //    //$('#saveDateForm input').attr('disabled', 'disabled');
    //});

    ////saveRoomForm
    //$('#next2').click(function (e) {
    //        e.preventDefault();
    //        $("#saveRoomDetails").submit();
    //        $('#booking-tabs a[href="#booking-reservation"]').tab('show');
    //        //$('#saveRoomForm input').attr('disabled', 'disabled');
        
    //});
          

    //$('#next3').click(function (e) {
    //    e.preventDefault();
    //    $("#submitCustomerData").submit();
    //    $('#booking-tabs a[href="#booking-confirmation"]').tab('show');
    //    //$('#submitCustomerData input').attr('disabled', 'disabled');
    //});

});

    $("#makeReservationNavTab").click(function () {
        //Remove tha active tab status key from localStorage
        localStorage.removeItem('activeTab');
}); 

    $('.datepicker').datepicker();

    //Limit the number of times the checkbox is checked upto the number of rooms 
    //that are selected in the reservation tab 2


//function checkLimit(totalNumberOfRooms) {

//    if (totalNumberOfRooms === document.saveRoomForm.ckb.length) {
//        if (totalNumberOfRooms === 1) {
//            document.getElementById("#displayErrorDiv").innerHTML =
//                totalNumberOfRooms + " room has already been selected. No more rooms can be selected";
//        }
//        else {
//            document.getElementById("#displayErrorDiv").innerHTML =
//                totalNumberOfRooms + " rooms has already been selected. No more rooms can be selected";

//        }
//    }
//}

    //$("#IsSingleRoom").click(function checkLimit() {
    //    $("input[type='checkbox']").change(function () {
    //        var cnt = $("input[type='checkbox']:checked").length;
    //        var _totalNumberOfRooms = 1;
    //        if (cnt > _totalNumberOfRooms) {
    //            $(this).prop("checked", "");
    //            document.getElementById("#displayErrorDiv").innerHTML =
    //                _totalNumberOfRooms + " rooms has already been selected. No more rooms can be selected";
    //        }
    //    });
    //});




//$(document).ready(function checkLimit(_totalNumberOfRooms) {
//    $("input[name='check']").change(function () {
//        var cnt = $("input[name='check']:checked").length;
//        if (cnt > _totalNumberOfRooms) {
//            $(this).prop("checked", "");
//            document.getElementById("#displayErrorDiv").innerHTML =
//                _totalNumberOfRooms + " rooms has already been selected. No more rooms can be selected";
//        }
//    });
//});



//$('#saveDateBtn').click(function () {
//    $("#saveForm").submit();
//});