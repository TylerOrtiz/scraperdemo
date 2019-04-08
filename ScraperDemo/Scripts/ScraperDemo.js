(function ($) {
    'use strict';
    var scraperDemo = {
        formElement: null,
        resultsElement: null,
        urlErrorsElement: null,
        totalWordsElement: null,
        carouselElement: null
    };

    function postToApi() {
        var targetUrl = $('input[name=url]', scraperDemo.formElement).val()
        var request = { Url: targetUrl };
        var scraperTarget = scraperDemo.formElement.attr('action');
        
        $.ajax({
            type: 'POST',
            url: scraperTarget,
            data: JSON.stringify(request),
            contentType: 'application/json'
        })
        .done(function (response) {
            showPageDetails(response);
        })
        .fail(function (error) {
            showErrors(error);
        });
    }

    function clearFormErrors() {
        scraperDemo.urlErrorsElement.text('');
    }

    function scraperFormSubmit(event) {
        event.preventDefault();
        clearFormErrors();
        scraperDemo.resultsElement.hide();
        postToApi();
    }

    function showPageDetails(data) {
        scraperDemo.resultsElement.show();
        updateWordCount(data.totalWords);
        updateCarousel(data.images);
        $('#urlWords').text(data.words);
    }

    function showErrors(error) {
        if (error.responseJSON.Url) {
            scraperDemo.urlErrorsElement.text(error.responseJSON.Url);
        } else {
            scraperDemo.urlErrorsElement.text('An error has occured');
            console.warn(error);
        }
    }

    function updateWordCount(count) {
        scraperDemo.totalWordsElement.text(count);
    }

    function updateCarousel(images) {
        console.log(images);
        $('.carousel-inner').empty();
        $('.carousel-indicators').empty();
        for (let j = 0; j < images.length; j++) {
            $(`<div class="carousel-item"><img src="${images[j]}" class="img-fluid mx-auto d-block w-50"></div>`).appendTo('.carousel-inner');
            $(`<li data-target="#scrapeCarousel" data-slide-to="${j}"></li > `).appendTo('.carousel-indicators')

        }

        $('.carousel-item').first().addClass('active');
        $('.carousel-indicators > li').first().addClass('active');
        scraperDemo.carouselElement.carousel();
    }

    $(document).ready(function () {
        scraperDemo.resultsElement = $('#scrapeResults');
        scraperDemo.formElement = $('#webscraperdemo');
        scraperDemo.urlErrorsElement = $('#urlerrors');
        scraperDemo.totalWordsElement = $('#totalWords');
        scraperDemo.carouselElement = $('#scrapeCarousel');

        scraperDemo.resultsElement.hide();

        if (scraperDemo.formElement && scraperDemo.formElement.length > 0) {
            scraperDemo.formElement.submit(scraperFormSubmit);
        }
    });
  
}(jQuery));