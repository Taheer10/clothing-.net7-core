﻿//const { Alert } = require("../lib/bootstrap/dist/js/bootstrap.bundle");

//$(document).ready(function () {
//    $("#StName").focus();

//    $("#StImage").change(function () {
//        const file = this.files[0];
//        if (file) {
//            const reader = new FileReader();
//            reader.onload = function (event) {
//                $("#StImage").data("base64", event.target.result);
//            };
//            reader.readAsDataURL(file);
//        }
//    });
//});


function getUrlPath() {
    // Get the current URL
    const currentUrl = window.location.href;

    // Create a URL object
    const url = new URL(currentUrl);

    // Construct the base URL
    const baseUrl = `${url.protocol}//${url.hostname}${url.port ? ':' + url.port : ''}/`;

    return baseUrl;
}

// Usage example
const basePath = getUrlPath();
console.log(basePath); // Will print the base URL with the correct port

//function ValidateSave() {
//    $("#SubmitButton").hide();
//    var stockInfo = {
//        StId: $("#StId").val(),
//        StName: $("#StName").val(),
//        StDes: $("#StDes").val(),
//        StInActive: $("#StInActive").val(),
//        StCode: $("#StCode").val(),
//        StImage: $("#StImage").data("base64"),
//        StIsPopular: $("#StIsPopular").val(),
//        StColour: $("#StColour").val(),
//        StSize: $("#StSize").val(),
//        StHSCode: $("#StHSCode").val(),
//        StIsShirt: $("#StIsShirt").val(),
//        StIsPant: $("#StIsPant").val(),
//        StIsOther: $("#StIsOther").val(),
//        StSortOrder: $("#StSortOrder").val(),
//        StMenuHeaderId: $("#StMenuHeaderId").val(),
//    };

//    $.ajax({
//        type: "POST",
//        url: getUrlPath() + "Stock/post-stock",
//        data: { model: stockInfo },
//        success: function (result) {
//            if (result == "success") {
//                alert('Data Saved Successfully');
//                window.location.reload();
//            } else {
//                //toastr.error(result);
//            }
//        },
//        error: function (result) {
//            alert("Cannot Save Data. Please try again.");
//        }
//    });
//}

//function ValidateSave() {
//    var stockInfo = {
//        StId: $("#StId").val(),
//        StName: $("#StName").val(),
//        StDes: $("#StDes").val(),
//        StInActive: $("#StInActive").val(),
//        StCode: $("#StCode").val(),
//        StIsPopular: $("#StIsPopular").val(),
//        StColour: $("#StColour").val(),
//        StSize: $("#StSize").val(),
//        StHSCode: $("#StHSCode").val(),
//        StIsShirt: $("#StIsShirt").val(),
//        StIsPant: $("#StIsPant").val(),
//        StIsOther: $("#StIsOther").val(),
//        StSortOrder: $("#StSortOrder").val(),
//        StMenuHeaderId: $("#StMenuHeaderId").val()
//    };

//    var formData = new FormData();
//    // Append stock info
//    formData.append("model", JSON.stringify(stockInfo));
//    // Append files
//    var files = $("#StImages").get(0).files;
//    for (var i = 0; i < files.length; i++) {
//        formData.append("StImages", files[i]);
//    }

//    $.ajax({
//        type: "POST",
//        url: getUrlPath() + "Stock/post-stock",
//        data: formData,
//        contentType: false,
//        processData: false,
//        success: function (result) {
//            if (result === "success") {
//                alert('Data Saved Successfully');
//                window.location.reload();
//            } else {
//                // Handle the error
//                alert("Error: " + result);
//            }
//        },
//        error: function (result) {
//            alert("Cannot Save Data. Please try again.");
//        }
//    });
//}

function addColorPicker() {
    var container = document.getElementById('color-picker-container');
    var newColorPicker = document.createElement('div');
    newColorPicker.className = 'color-picker';
    newColorPicker.innerHTML = `
                <input type="color" name="colors" />
                <button type="button" class="fa fa-trash text-danger" onclick="removeColor(this)"></button>
            `;
    container.appendChild(newColorPicker);
}

function removeColor(button) {
    var colorPicker = button.parentElement;
    colorPicker.remove();
}

function getColors() {
    var colors = [];
    var colorPickers = document.querySelectorAll('#color-picker-container input[name="colors"]');
    colorPickers.forEach(function (picker) {
        colors.push(picker.value);
    });
    return colors.join(';');
}

function ValidateSave() {
    $("#SubmitButton").hide();
    var stockInfo = {
        StId: $("#StId").val(),
        StName: $("#StName").val(),
        StDes: $("#StDes").val(),
        StImageUpdate: $("#StImageUpdate").val(),
        StInActive: $("#StInActive").val(),
        StCode: $("#StCode").val(),
        StIsPopular: $("#StIsPopular").val(),
        //StColour: $("#StColour").val(),
        StSize: $("#StSize").val(),
        StHSCode: $("#StHSCode").val(),
        StIsShirt: $("#StIsShirt").val(),
        StIsPant: $("#StIsPant").val(),
        StIsOther: $("#StIsOther").val(),
        StSortOrder: $("#StSortOrder").val(),
        StMenuHeaderId: $("#StMenuHeaderId").val()
    };


    var formData = new FormData();
    // Append model data as a JSON string
    formData.append("model", JSON.stringify(stockInfo));

    var colors = getColors(); // Function to get the selected colors
    formData.append("StColours", colors);

    // Append files
    var files = $("#StImages").get(0).files;
    for (var i = 0; i < files.length; i++) {
        formData.append("StImages", files[i]);
    }

    $.ajax({
        type: "POST",
        url: getUrlPath() + "Stock/post-stock",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
            if (result === "success") {
                alert('Data Saved Successfully');
                //window.location.reload();
                window.location.href = getUrlPath() + "Stock/Index";
            } else {
                // Handle the error
                alert("Error: " + result);
            }
        },
        error: function (result) {
            alert(result.responseText);
            //alert("Cannot Save Data. Please try again.");
        }
    });
}





//function SaveBanner() {
//    $("#bannersavebtn").hide();
//    var bannerInfo = {
//        BannerId: $("#BannerId").val(),
//        BannerImg: $("#BannerImg").val(),
//        BannerIsActive: $("#BannerIsActive").val(),
//        StSortOrder: $("#StSortOrder").val(),

//    };


//    var formData = new FormData();
//    formData.append("model", JSON.stringify(bannerInfo));


//    $.ajax({
//        type: "POST",
//        url: getUrlPath() + "Banner/CreatePost",
//        data: formData,
//        contentType: false,
//        processData: false,
//        success: function (result) {
//            if (result === "success") {
//                alert('Data Saved Successfully');
//                //window.location.reload();
//                window.location.href = getUrlPath() + "Stock/Index";
//            } else {
//                // Handle the error
//                alert("Error: " + result);
//            }
//        },
//        error: function (result) {
//            alert(result.responseText);
//            //alert("Cannot Save Data. Please try again.");
//        }
//    });
//}




//function displayLatestItems() {
//    var fromdate = $("#fromdate").val();
//    var todate = $("#todate").val();
//    window.location.href = getUrlPath() + "Home/StockLatetsItems?FromDate=" + fromdate + "&Todate=" + todate;
//}

//function displayLatestItems() {
//    alert(10)
//    var fromdate = $("#fromdate").val();
//    var todate = $("#todate").val();
//    alert(fromdate)
//    alert(todate)
//    window.location.href = getUrlPath() + "Home/StockLatetsItems?FromDate=" + fromdate + "&Todate=" + todate;
//}

function createstock(stId) {
    if (stId && stId !== 0) {
        //window.location.href = getUrlPath() + "stock/create-stock?StId=" + stId;
        window.location.href = getUrlPath() + "stock/stockdetail?StId=" + stId;
    } else {
        alert("Select Item");
    }
}

function OpenStockDetail(stId) {
    if (stId && stId !== 0) {
        window.location.href = getUrlPath() + "stock/stockdetail?StId=" + stId;
    } else {
        alert("Select Item");
    }
}
function Editstock(stId) {
    if (stId && stId !== 0) {
        window.location.href = getUrlPath() + "stock/create-stock?StId=" + stId;
    } else {
        alert("Select Item");
    }
}

function showMenuHeader() {
    $("#menuheadertitle").show();
    $("#navbarlist").show();
    $("#hidemenuheader").show();
    $("#showmenuheader").hide();

}

function hideMenuHeader() {
    $("#menuheadertitle").hide();
    $("#navbarlist").hide();
    $("#showmenuheader").show();
    $("#hidemenuheader").hide();

}

function deletestock(stId) {
    if (stId && stId !== 0) {
        window.location.href = getUrlPath() + "stock/Delete?StId=" + stId;
    } else {
        alert("Select Item");
    }
}

function deletestock(stId) {
    if (stId === 0 || stId === null) {
        alert("Please select Item to Delete");
        return; // Exit function if no valid stId
    }

    var userConfirmed = confirm('Are you sure you want to delete?');
    if (!userConfirmed) {
        return false;
    }

    $.ajax({
        type: "POST",
        url: getUrlPath() + "Stock/Delete",
        data: { StId: stId }, // Send the data as JSON
        success: function (result) {
            if (result == true) {
                alert('Data Deleted Successfully');
                // Optionally, refresh the page or update the UI
            } else {
                //alert("Error: " + result); // Better to show the error message if available
                window.location.reload();
                alert('Data Deleted Successfully');

            }
        },
        error: function (result) {
            alert("Cannot Delete Data. Please try again.");
        }
    });
}



function imgSrc(id) {
    var imgElement = $('#' + id);
    //debugger
    // Retrieve the src and name attributes
    var imgSrc = imgElement.attr('src');
    var imgName = imgElement.attr('name');

    $("#stimageindividual").attr('src', imgSrc)
    var stflag = $("#StFlagValId").val();
    if (stflag == 1) {
        $("#commonselectedcolorName").text("Color Family:" + " " + imgName);
    }
}

function ChangeImgSrc(id) {
    debugger
    var tagLink = $(`#stimagelist-${id}`);
    var imgtage = tagLink.attr('src');
    $("#stimageindividual").attr('src', imgtage)
}

//function ChangeNormalImgSrc(id) {
//    debugger
//    var tagLink = $(`#stimagelist-${id}`);
//    var imgtage = tagLink.attr('src');
//    $("#stimageindividual").attr('src', imgtage)
//}


function addColorImages() {
    var stockid = $("#StId").val();
    window.location.href = getUrlPath() + "ColorImages/Create?stkid=" + stockid;
}

function FilterList() {
    var isactive = $("#stklist").val();
    window.location.href = getUrlPath() + "stock/Index?inActive=" + isactive;
}

function openDetail(stId) {
    window.location.href = getUrlPath() + "stock/create-stock?StId=" + stId;
}

function displayPopularItems() {
    window.location.href = getUrlPath() + "stock/StockPopularItems";
}

function displayLatestItems() {
    window.location.href = getUrlPath() + "Home/StockLatetsItems";
}

function RedirectBanner() {
    window.location.href = getUrlPath() + "Banner/Create";
}

function changeStatus(id) {
    var FlagValue = id;
    var stockId = $("#StId").val();
    $.ajax({
        type: "POST",
        url: getUrlPath() + "Stock/UpdateFlag",
        data: { stockId: stockId, FlagVal: FlagValue }, // Send the data as JSON
        success: function (result) {
            if (result.success == true) {
                alert(result.message);
                window.location.reload();
                // Optionally, refresh the page or update the UI
            }
            //else {
            //    //alert("Error: " + result); // Better to show the error message if available
            //    window.location.reload();
            //    alert('Flag Updated Successfully');

            //}
        },
        error: function (result) {
            alert(result.message);
        }
    });
}

function SaveBanner() {
    $("#bannersavebtn").hide();
    var bannerInfo = {
        BannerId: $("#BannerId").val(),
        BannerIsActive: $("#BannerIsActive").val(),
        BannerSortOrder: $("#BannerSortOrder").val(),

    };

    // Create a new FormData object
    var formData = new FormData();

    // formData.append("BannerId", $("#BannerId").val());
    // formData.append("BannerIsActive", $("#BannerIsActive").val());
    // formData.append("StSortOrder", $("#StSortOrder").val());
    debugger;

    var fileInput = document.getElementById("BannerImg");
    if (fileInput.files.length > 0) {
        formData.append("BannerImg", fileInput.files[0]);
    }

    formData.append("model", JSON.stringify(bannerInfo));

    $.ajax({
        type: "POST",
        url: getUrlPath() + "Banner/CreatePost",
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
            if (result.success) {
                window.location.href = getUrlPath() + "Banner/Index";
                alert(result.message);

            } else {
                alert("Error: " + result.responseText);
            }
        },
        error: function (result) {
            debugger
            // alert("Cannot Save Data. Please try again.");
            alert("Error: " + result.responseText);
        }
    });
}

function saveMenuHeader() {
    $("#SubmitButton").hide();
    var menuInfo = {
        MenuHeaderId: $("#MenuHeaderId").val(),
        MenuHeaderName: $("#MenuHeaderName").val(),
        MenuHeaderIsActive: $("#MenuHeaderIsActive").val(),
        StSortOrder: $("#StSortOrder").val(),

    };

    $.ajax({
        type: "POST",
        url: getUrlPath() + "MenuHeader/CreatePost",
        data: { model: menuInfo },
        success: function (result) {
            if (result == "success") {
                alert('Data Saved Successfully');
                window.location.reload();
            } else {
                //toastr.error(result);
            }
        },
        error: function (result) {
            alert("Cannot Save Data. Please try again.");
        }
    });
}

function saveCompanyDetail() {
    $("#SubmitCompanyButton").hide();
    var CompanyInfo = {
        CompanyId: $("#CompanyId").val(),
        CompanyName: $("#CompanyName").val(),
        ContactNo: $("#ContactNo").val(),
        CompanyEmail: $("#CompanyEmail").val(),
        Slogan1: $("#Slogan1").val(),
        Slogan2: $("#Slogan2").val(),
        Slogan3: $("#Slogan3").val(),

    };

    $.ajax({
        type: "POST",
        url: getUrlPath() + "Company/CreatePost",
        data: { model: CompanyInfo },
        success: function (result) {
            if (result == "success") {
                alert('Data Saved Successfully');
                window.location.reload();
            } else {
                //toastr.error(result);
            }
        },
        error: function (result) {
            alert("Cannot Save Data. Please try again.");
        }
    });
}

function deleteBanner(bnId) {
    if (bnId === 0 || bnId === null) {
        alert("Please select Item to Delete");
        return; // Exit function if no valid stId
    }

    var userConfirmed = confirm('Are you sure you want to delete?');
    if (!userConfirmed) {
        return false;
    }

    $.ajax({
        type: "POST",
        url: getUrlPath() + "Banner/Delete",
        data: { bnId: bnId },
        success: function (result) {
            if (result == true) {
                alert('Data Deleted Successfully');
            } else {
                window.location.reload();
                alert('Data Deleted Successfully');

            }
        },
        error: function (result) {
            alert("Cannot Delete Data. Please try again.");
        }
    });
}

function RedirectStockCreate() {
    window.location.href = getUrlPath() + "Stock/Create-Stock";

}

function createMenuHeader(id) {
    window.location.href = getUrlPath() + "MenuHeader/Create?mnId=" + id;
}
function createBanner(bnId) {
    window.location.href = getUrlPath() + "Banner/Create?bnId=" + bnId;
}

function getStockMenuList(id) {
    window.location.href = getUrlPath() + "MenuHeader/GetStockMenuDetail?mnId=" + id;
}

function GotoHome() {
    window.location.href = getUrlPath() + "Home/Index";
}

function RedirectMenuHeader() {
    window.location.href = getUrlPath() + "MenuHeader/Create";
}

function createColorImages(id) {
    if (id === 0 || id === null) {
        alert("Please select ");
        return;
    }

    window.location.href = getUrlPath() + "ColorImages/Create?ClrId=" + id;
}

//function createColorImages(id) {
//    if (id === 0 || id === null) {
//        alert("Please select ");
//        return;
//    }

//    //window.location.href = getUrlPath() + "ColorImages/Create?ClrId=" + id;
//    $.ajax({
//        type: "GET",
//        url: getUrlPath() + "ColorImages/Create?ClrId=" + id,
//        success: function (model) {
//            debugger
//            var result = model;
//            window.location.href = getUrlPath() + "ColorImages/CreateInfo?ClrinfoId=" + result.model.colorImagesId + "&colorImagesList=" + result.model.colorImagesList;

//            ////result = JSON.parse(model);
//            //var obj = [result.model];


//            console.log(result);
//        },
//        error: function (result) {

//        }
//    });

//}

function deleteMenuHeader(mnId) {
    if (mnId === 0 || mnId === null) {
        alert("Please select Item to Delete");
        return; // Exit function if no valid stId
    }

    var userConfirmed = confirm('Are you sure you want to delete?');
    if (!userConfirmed) {
        return false;
    }

    $.ajax({
        type: "POST",
        url: getUrlPath() + "MenuHeader/Delete",
        data: { mnId: mnId }, // Send the data as JSON
        success: function (result) {
            if (result == true) {
                alert('Data Deleted Successfully');
                // Optionally, refresh the page or update the UI
            } else {
                //alert("Error: " + result); // Better to show the error message if available
                window.location.reload();
                alert('Data Deleted Successfully');

            }
        },
        error: function (result) {
            alert("Cannot Delete Data. Please try again.");
        }
    });
}


function OpenImageDetail(imagePath) {
    window.open(imagePath, '_blank');
}

function ChangeImageDetail(imageUrl) {
    $(".stockimagecontained").attr("src", imageUrl);
}