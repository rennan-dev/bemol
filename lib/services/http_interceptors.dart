import 'dart:developer';
import 'package:http_interceptor/http_interceptor.dart';
import 'package:logger/logger.dart';

class LoggerInterceptor extends InterceptorContract {
  final Logger logger = Logger();

  @override
  Future<BaseRequest> interceptRequest({
    required BaseRequest request,
  }) async {
    log('----- Request -----');
    logger.d(
      "Requisição para: ${request.url}\n"
          "Método: ${request.method}\n"
          "Cabeçalhos: ${request.headers}\n"
          "Corpo: ${request is Request ? request.body : 'Sem corpo'}",
    );
    return request;
  }

  @override
  Future<BaseResponse> interceptResponse({
    required BaseResponse response,
  }) async {
    log('----- Response -----');
    logger.i(
      "Resposta para: ${response.request?.url}\n"
          "Código de Status: ${response.statusCode}\n"
          "Cabeçalhos: ${response.headers}\n"
          "Corpo: ${response is Response ? response.body : 'Sem corpo'}",
    );

    if (response.statusCode >= 400) {
      logger.e(
        "Erro detectado na resposta.\n"
            "Código de Status: ${response.statusCode}\n"
            "Erro: ${response is Response ? response.body : 'Detalhes indisponíveis'}",
      );
    }

    return response;
  }
}
