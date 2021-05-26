// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function video(idTemaContenido, idCurso) {
    var $videoSeccion = $('div#video');
    $.ajax({
        'url': '/CursoTemas/Video?idTemaContenido=' + idTemaContenido + '&idCurso=' + idCurso,
        'type': 'get'
    }).done(function (items) {
        var options = `<iframe muted paused class="video embed-responsive-item" width="730" height="430" src="${items.videos}" ></iframe>`
        $videoSeccion.html(options);
        reloadSeries()
    })
}

// Write your JavaScript code.
