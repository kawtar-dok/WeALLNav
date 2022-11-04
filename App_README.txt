Vous avez ajouté un complément Office.

Pour utiliser le style et la fonctionnalité Office pour une page HTML donnée, ajoutez les
références suivantes à la section <head> de la page, en modifiant les chemins d'accès relatifs si nécessaire :

    <!-- Références Office :-->
    <link href="Content/Office.css" rel="stylesheet" type="text/css" />
    <script src="https://appsforoffice.microsoft.com/lib/1/hosted/office.js"></script>

    <!-- Pour activer le débogage hors connexion à l'aide d'une référence locale à Office.js, utilisez :                  -->
    <!--    <script src="Scripts/Office/MicrosoftAjax.js" type="text/javascript"></script>       -->
    <!--    <script src="Scripts/Office/1/office.js" type="text/javascript"></script>          -->


Notez que la fonction initialize Office doit être appelée avant toute interaction de 
JavaScript avec l'API Office (une fois par page) :

    Office.initialize = function (reason) {
        $(document).ready(function () {
            // Ajoutez ici la logique d'initialisation.
        });
    };
