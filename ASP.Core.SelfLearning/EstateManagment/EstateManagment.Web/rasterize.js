"use strict";
var page = require('webpage').create(),
    system = require('system'),
    address,
    output;

console.log('Usage: rasterize.js [URL] [filename] [paperformat]');
address = system.args[1];
output = system.args[2];
page.viewportSize = { width: 600, height: 600 };
page.paperSize = { format: system.args[3], orientation: 'portrait', margin: '0.5cm' };

page.open(address, function (status) {
    if (status !== 'success') {
        console.log('Unable to load the address!');
        phantom.exit(1);
    } else {
        window.setTimeout(function () {
            page.render(output);
            phantom.exit();
        }, 200);
    }
});