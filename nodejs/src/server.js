var http = require("http");
var url = require("url");

function start(route, handle) {
	function onRequest(request, response) {
		var pathname = url.parse(request.url).pathname;
		// var postData = "";
		console.log("Request for " + pathname + " received.");
		route(handle, pathname, response, request);
		/*
		request.setEncoding("utf8");
		
		request.addListener("data", function(postDataChunk) {
			postData += postDataChunk;
			console.log("Received POST data chunk '" + postDataChunk + "'." );
		});
		
		request.addListener("end", function() {
			route(handle, pathname, response, postData);
		});
		*/
		//route(handle, pathname, response);
		/*
		var content = route(handle, pathname);
		
		response.writeHead(200, {"Content-Type": "text/plain"});
		response.write(content);
		response.end();*/
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