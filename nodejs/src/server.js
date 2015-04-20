var http = require("http");

function start() {
	function onRequest(request, response) {
		console.log("Request received.");
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