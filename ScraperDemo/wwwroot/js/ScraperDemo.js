(function ($) {
    'use strict';
    var scraperDemo = {
        formElement: null,
        resultsElement: null,
        urlErrorsElement: null,
        totalWordsElement: null,
        carouselElement: null,
        chartElement: null,
        chartObject: null
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
        updateChart(data.words);
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

    function updateChart(words) {
        console.log(words);
        words.sort(function (first, second) {
            if (first.count < second.count) {
                return 1;
            }

            if (first.count > second.count) {
                return -1;
            }

            return 0;
        });
        var targetWords = words.slice(0, 11);

        var chartLabels = targetWords.map(function (e) {
            return e.key;
        });
        var chartPoints = targetWords.map(function (e) {
            return e.count;
        });

        if (scraperDemo.chartObject === null) {
            scraperDemo.chartObject = new Chart(scraperDemo.chartElement, {
                type: 'horizontalBar',
                data: {
                    datasets: [{}]
                },
                options: {
                    title: {
                        display: true,
                        text: 'Top 10 most commonly used words'
                    },
                    legend: {
                        display: false
                    }
                }
            });
        }

        scraperDemo.chartObject.data.labels.pop();
        scraperDemo.chartObject.data.datasets.forEach((dataset) => {
            dataset.data.pop();
        });
        scraperDemo.chartObject.update();

        scraperDemo.chartObject.data.labels = chartLabels;
        scraperDemo.chartObject.data.datasets.forEach((dataset) => {
            dataset.data = chartPoints;
            dataset.backgroundColor = [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)'
            ];
        });
        scraperDemo.chartObject.update();
    }

    $(document).ready(function () {
        scraperDemo.resultsElement = $('#scrapeResults');
        scraperDemo.formElement = $('#webscraperdemo');
        scraperDemo.urlErrorsElement = $('#urlerrors');
        scraperDemo.totalWordsElement = $('#totalWords');
        scraperDemo.carouselElement = $('#scrapeCarousel');
        scraperDemo.chartElement = $('#scrapeChart');

        scraperDemo.resultsElement.hide();

        if (scraperDemo.formElement && scraperDemo.formElement.length > 0) {
            scraperDemo.formElement.submit(scraperFormSubmit);
        }
    });
  
}(jQuery));