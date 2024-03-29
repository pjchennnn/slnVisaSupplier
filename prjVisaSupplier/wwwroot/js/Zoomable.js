﻿//const map = document.getElementById('map')

! function (t, e) {
    "object" == typeof exports && "undefined" != typeof module ? module.exports = e() : "function" == typeof define && define.amd ? define(e) : t.zoomableSvg = e()
}(this, function () {
    "use strict";
    var t = window;
    return function (e, n) {
        function i(t, e, n) {
            function i(t, e, n) {
                return Math.max(e, Math.min(t, n))
            }
            var o = e.getBoundingClientRect(),
                r = t.clientX - o.left,
                a = t.clientY - o.top;
            return n && (r = i(r, 0, o.width), a = i(a, 0, o.height)), {
                x: r,
                y: a
            }
        }

        function o(t, e) {
            this.x = t, this.y = e
        }
        o.prototype.negate = function () {
            return new o(-this.x, -this.y)
        }, o.prototype.subtract = function (t) {
            return new o(this.x - t.x, this.y - t.y)
        }, "string" == typeof e && (e = document.querySelector(e));
        var r = (n = n || {}).container || e,
            a = void 0,
            c = void 0,
            u = void 0,
            l = void 0,
            h = void 0;

        function f(t, e) {
            d(u *= 1 + t, e)
        }

        function d(t, e) {
            var n, i = l.width / t,
                r = l.height / t,
                a = i / h.width,
                c = {
                    w: l.width * a,
                    h: l.height * a,
                    t: e.y - e.y * a,
                    l: e.x - e.x * a
                };
            n = g(new o(c.l, c.t)), h.top = n.y, h.left = n.x, h.width = i, h.height = r, v()
        }

        function s(t) {
            var e = g(t.negate());
            h.top = e.y, h.left = e.x, v()
        }

        function g(t) {
            var e = t.x / l.width,
                n = t.y / l.height;
            return new o(h.width * e + h.left, h.height * n + h.top)
        }

        function v() {
            var t = p();
            e.setAttribute("viewBox", t), n.onChanged && n.onChanged.call(w)
        }

        function p() {
            return [h.left, h.top, h.width, h.height]
        }
        var w = {
            Coord: o,
            vp2vb: g,
            getZoom: function () {
                return u
            },
            setZoom: d,
            moveViewport: s,
            getViewBox: p
        };

        
        e.addEventListener('dblclick', function (event) {
            // 双击时将图形状态重置为初始状态
            u = 1; // 重置缩放比例

            // 获取当前SVG的宽度和高度
            var svgWidth = 960;
            var svgHeight = 480;

            // 添加过渡效果
            e.style.transition = "viewBox 1s ease-in-out";

            h = {
                left: 0,
                top: 10,
                width: svgWidth,
                height: svgHeight
            }; // 重置视口状态

            v(); // 更新视口

            // 监听过渡完成事件，然后移除过渡效果
            e.addEventListener('transitionend', function transitionEndHandler() {
                e.style.transition = ""; // 移除过渡效果
                e.removeEventListener('transitionend', transitionEndHandler); // 移除事件监听器
            });
        });

        return function () {
            function n() {
                u = l.width / h.width, f(0, new o(0, 0))
            }
            l = {
                width: r.clientWidth,
                height: r.clientHeight
            }, (h = function (t) {
                var e = t && t.split(/[ ,]/).filter(function (t) {
                    return t.length
                }).map(function (t) {
                    return Number(t)
                });
                if (e && 4 === e.length) return {
                    left: e[0],
                    top: e[1],
                    width: e[2],
                    height: e[3]
                }
            }(e.getAttribute("viewBox"))) ? n() : (u = 1, h = {
                left: 0,
                top: 0,
                width: l.width,
                height: l.height
            }, v()), window.addEventListener("resize", function (t) {
                l = {
                    width: r.clientWidth,
                    height: r.clientHeight
                }, n()
            }), r.addEventListener("wheel", function (t) {
                t.preventDefault(), f(t.deltaY > 0 ? -.1 : .1, i(t, r))
            }), r.addEventListener("touchmove", function (t) {
                var e = t.touches;
                if (2 === e.length) {
                    t.preventDefault();
                    var n = i(e[0], r),
                        a = i(e[1], r),
                        u = n.x - a.x,
                        l = n.y - a.y,
                        h = {
                            center: new o((n.x + a.x) / 2, (n.y + a.y) / 2),
                            dist: Math.sqrt(u * u + l * l)
                        };
                    c && (s(h.center.subtract(c.center)), f(h.dist / c.dist - 1, h.center)), c = h
                } else c = null
            }), r.addEventListener("touchend", function (t) {
                c = null
            }),
                function (e) {
                    var n = Element.prototype;
                    n.matches || (n.matches = n.msMatchesSelector || n.webkitMatchesSelector), n.closest || (n.closest = function (t) {
                        var e = this;
                        do {
                            if (e.matches(t)) return e;
                            e = "svg" === e.tagName ? e.parentNode : e.parentElement
                        } while (e);
                        return null
                    });
                    var i = (e = e || {}).container || document.documentElement,
                        o = e.selector,
                        r = e.callback || console.log,
                        a = e.callbackDragStart,
                        c = e.callbackDragEnd,
                        u = e.callbackClick,
                        l = e.propagateEvents,
                        h = !1 !== e.roundCoords,
                        f = !1 !== e.dragOutside,
                        d = e.handleOffset || !1 !== e.handleOffset,
                        s = null;
                    switch (d) {
                        case "center":
                            s = !0;
                            break;
                        case "topleft":
                        case "top-left":
                            s = !1
                    }
                    var g = void 0;

                    function v(t, e, n, o) {
                        var r = t.clientX,
                            a = t.clientY;

                        function c(t, e, n) {
                            return Math.max(e, Math.min(t, n))
                        }
                        if (e) {
                            var u = e.getBoundingClientRect();
                            r -= u.left, a -= u.top, n && (r -= n[0], a -= n[1]), o && (r = c(r, 0, u.width), a = c(a, 0, u.height)), e !== i && (null !== s ? s : "circle" === e.nodeName || "ellipse" === e.nodeName) && (r -= u.width / 2, a -= u.height / 2)
                        }
                        return h ? [Math.round(r), Math.round(a)] : [r, a]
                    }

                    function p(t) {
                        t.preventDefault(), l || t.stopPropagation()
                    }

                    function w(t) {
                        var e = void 0;
                        if (e = o ? o instanceof Element ? o.contains(t.target) ? o : null : t.target.closest(o) : {}) {
                            p(t);
                            var n = o && d ? v(t, e) : [0, 0],
                                r = v(t, i, n);
                            g = {
                                target: e,
                                mouseOffset: n,
                                startPos: r,
                                actuallyDragged: !1
                            }, a && a(e, r)
                        }
                    }

                    function m(t) {
                        if (g) {
                            p(t);
                            var e = g.startPos,
                                n = v(t, i, g.mouseOffset, !f);
                            g.actuallyDragged = g.actuallyDragged || e[0] !== n[0] || e[1] !== n[1], r(g.target, n, e)
                        }
                    }

                    function y(t, e) {
                        if (g) {
                            p(t);
                            var n = !g.actuallyDragged,
                                o = n ? g.startPos : v(t, i, g.mouseOffset, !f);
                            u && n && !e && u(g.target, o), c && c(g.target, o, g.startPos, e || n && u)
                        }
                        g = null
                    }

                    function b(t, e) {
                        y(k(t), e)
                    }

                    function x(t, e, n) {
                        t.addEventListener(e, n)
                    }

                    function D(t) {
                        return void 0 !== t.buttons ? 1 === t.buttons : 1 === t.which
                    }

                    function E(t, e) {
                        1 === t.touches.length ? e(k(t)) : y(t, !0)
                    }

                    function k(t) {
                        var e = t.targetTouches[0];
                        return e || (e = t.changedTouches[0]), e.preventDefault = t.preventDefault.bind(t), e.stopPropagation = t.stopPropagation.bind(t), e
                    }
                    x(i, "mousedown", function (t) {
                        D(t) ? w(t) : y(t, !0)
                    }), x(i, "touchstart", function (t) {
                        return E(t, w)
                    }), x(t, "mousemove", function (t) {
                        g && (D(t) ? m(t) : y(t))
                    }), x(t, "touchmove", function (t) {
                        return E(t, m)
                    }), x(i, "mouseup", function (t) {
                        g && !D(t) && y(t)
                    }), x(i, "touchend", function (t) {
                        return b(t)
                    }), x(i, "touchcancel", function (t) {
                        return b(t, !0)
                    })
                }({
                    container: r,
                    callbackDragStart: function (t, e) {
                        a = e
                    },
                    callback: function (t, e, n) {
                        s(new o(e[0] - a[0], e[1] - a[1])), a = e
                    },
                    callbackDragEnd: function () {
                        a = null
                    }
                })
        }(), w
    }
});
