function insertdata(url, data) {
    return $.ajax({
        url: url,
        data: data,
        type: 'post',
        success: function (res) {
           
        },
        error: function (err) {
            console.log(err);
            alert('An internal server error occurred.  Please try again later');
        }
    })
}