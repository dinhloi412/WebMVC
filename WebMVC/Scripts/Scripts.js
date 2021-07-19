function ShowImagePreview(imgaeUpload, previewImage) {
    if (imgaeUpload.files && imgaeUpload.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);

        }
        reader.readAsDataURL(imgaeUpload.files[0]);
    }
}