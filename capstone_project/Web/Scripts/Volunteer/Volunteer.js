    var badges = $('.badge');

    var i;
    for (i = 0; i < badges.length; ++i) {
        var id = "#" + badges[i].id;
        console.log($(id));
        var initialText = $(id).clone().html();
        $(id).html("");
        var circle = new ProgressBar.Circle((id), {
            strokeWidth: 3,
            color: '#D64541',
            trailColor: '#f4f4f4'
        });
        circle.setText(initialText);

        circle.animate(Math.random());  // Number from 0.0 to 1.0
    }

    
    /*------- Radar Chart -------*/
    var radarChartData = {
        labels: ["Education", "Homelessness", "Medicine", "Sustainability", "Animals", "Employment", "Technology"],
        datasets: [
            {
                fillColor: "rgba(220,220,220,0.5)",
                strokeColor: "rgba(220,220,220,1)",
                pointColor: "rgba(220,220,220,1)",
                pointStrokeColor: "#fff",
                data: [8, 2, 7, 1, 8, 5, 10]
            },
            {
                fillColor: "rgba(151,187,205,0.5)",
                strokeColor: "rgba(151,187,205,1)",
                pointColor: "rgba(151,187,205,1)",
                pointStrokeColor: "#fff",
                data: [9, 5, 3, 5, 1, 5, 8]
            }
        ]

    }

    var myRadar = new Chart(document.getElementById("canvas").getContext("2d")).Radar(radarChartData, { scaleShowLabels: true, pointLabelFontSize: 10 });
