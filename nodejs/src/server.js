var http = require("http");
var url = require("url");

function start() {
	function onRequest(request, response) {
		var pathname = url.parse(request.url).pathname;
		
		console.log("Request for " + pathname + " received.");
		
		response.writeHead(200, {"Content-Type": "text/plain"});
		response.write("Hello World");
		response.end();
	}
	
	http.createServer(onRequest).listen(8888);
	console.log("Server has started.");
}

exports.start = start;

/*
http.createServer(function(req, res){
	console.log("Request received.")
	res.writeHead(200, {"Content-Type": "text/plain"});
	res.write("Hello World");
	res.end();
}).listen(8888);

console.log("Server has started.")
*/