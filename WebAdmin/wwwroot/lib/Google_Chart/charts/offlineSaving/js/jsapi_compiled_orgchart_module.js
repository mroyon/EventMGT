var gvjs_BW="google-visualization-orgchart-connrow-";function gvjs_CW(a){gvjs_Tq.call(this,a);this.m={};this.J=null;this.H=gvjs_7o();this.vc=new gvjs_br;this.yh=null}gvjs_p(gvjs_CW,gvjs_Tq);gvjs_CW.prototype.O0=0;gvjs_CW.prototype.Qg=function(a,b,c){this.m=a=c||{};this.J=b;if(!this.container)throw Error(gvjs_ij);if(!b)throw Error(gvjs_bt);b=new gvjs_kO(b,{N9:!1,O9:!1,n$:!1});this.yh=new gvjs_lO(b,function(a){return new gvjs_DW(a)});this.BE(this.yh,a);gvjs_T(this,gvjs_I,{})};
function gvjs_DW(a){gvjs_gO.call(this,a.getId(),a.getName());this.row=a.getId();this.npa=gvjs_iO(a);this.style=a.Mq(gvjs_Gb);this.Bxa=a.Mq("selectedStyle");this.label=3==a.bb().Z()?a.Ta(2):null;this.g4=this.x=null;this.collapsed=!1}gvjs_p(gvjs_DW,gvjs_gO);function gvjs_EW(a,b){var c=[];a.yh.RL(function(a,e){e==b&&c.push(a);return!a.collapsed&&e<b},a);gvjs_1c(c,function(a,b){return a.row-b.row});return c}
function gvjs_FW(a,b){var c=b.hf(),d=c.length;if(0==d)b.x=a.O0++;else{for(var e=0;e<d;e++)gvjs_FW(a,c[e]);b.x=(c[0].x+c[d-1].x)/2}}gvjs_=gvjs_CW.prototype;
gvjs_.BE=function(a,b){var c=this.container;this.O0=0;for(var d=gvjs_EW(this,0),e=0;e<d.length;e++)gvjs_FW(this,d[e]);d=b.size;"large"!=d&&"small"!=d&&(d=gvjs_ob);var f=this.H,g=f.G(gvjs_Qa,{"class":"google-visualization-orgchart-table",dir:gvjs_7w,cellpadding:"0",cellspacing:"0",align:gvjs__}),h=f.G(gvjs_Ra);f.appendChild(g,h);var k=8*this.O0-2,l=f.G(gvjs_Ua,null);f.appendChild(h,l);for(var m=0;m<k;m++){var n=f.G(gvjs_Sa,{"class":"google-visualization-orgchart-space-"+d});f.appendChild(l,n)}a=a.getHeight()+
1;for(l=0;l<a;l++){m=gvjs_EW(this,l);if(0<l){var p=[];for(var q=0;q<m.length;q++){var r=m[q];n=r.getParent();e=Math.round(8*r.x+3);n.x>=r.x?((n=p[e])||(n=p[e]={}),n.borderLeft=!0):((n=p[--e])||(n=p[e]={}),n.borderRight=!0)}gvjs_GW(this,p,k,h,gvjs_BW+d,d,b)}p=[];for(q=0;q<m.length;q++)r=m[q],e=Math.round(8*r.x),(n=p[e])||(n=p[e]={}),n.node=r,n.span=6;gvjs_GW(this,p,k,h,"google-visualization-orgchart-noderow-"+d,d,b);if(l!=a){p=[];for(q=0;q<m.length;q++){r=m[q];var t=r.hf();if(0<t.length&&(e=Math.round(8*
r.x+3),(n=p[e])||(n=p[e]={}),n.borderLeft=!0,!r.collapsed))for(r=Math.round(8*t[t.length-1].x+3),e=Math.round(8*t[0].x+3);e<r;e++)(n=p[e])||(n=p[e]={}),n.borderBottom=!0}gvjs_GW(this,p,k,h,gvjs_BW+d,d,b)}}f.uc(c);f.appendChild(c,g)};
function gvjs_GW(a,b,c,d,e,f,g){var h=g.nodeClass||"google-visualization-orgchart-node",k=a.H;e=k.G(gvjs_Ua,{"class":e});k.appendChild(d,e);for(d=0;d<c;d++){var l=b[d],m=k.G(gvjs_Sa,null);if(!l){l={empty:!0};for(var n=d+1;n<c&&!b[n];)n++;l.span=n-d}(n=l.span)&&1<n&&(m.colSpan=n,d+=n-1);if(l.node){l.node.g4=m;n=h+" google-visualization-orgchart-node-"+f;var p=l.node.row;null!=p&&(gvjs_Q(m,gvjs_wl,gvjs_o(a.yZ,a,p)),gvjs_Q(m,gvjs_Bl,gvjs_o(a.AZ,a,p)),gvjs_Q(m,gvjs_Al,gvjs_o(a.zZ,a,p)),a.m.allowCollapse&&
gvjs_Q(m,gvjs_2j,gvjs_o(a.Tqa,a,p)))}else n="google-visualization-orgchart-linenode",l.borderLeft&&(n+=" google-visualization-orgchart-lineleft"),l.borderRight&&(n+=" google-visualization-orgchart-lineright"),l.borderBottom&&(n+=" google-visualization-orgchart-linebottom");n&&(m.className=n,-1<n.indexOf(h)&&(g.color&&(m.style.background=g.color),n=l.node&&l.node.style))&&(m.style.cssText=n);n=l.node?l.node.npa:"\u00a0";l=l.node?l.node.label:null;null!=l&&(m.title=l);g.allowHtml?m.innerHTML=n:k.appendChild(m,
k.createTextNode(n));k.appendChild(e,m)}}gvjs_.getSelection=function(){return this.vc.getSelection()};
gvjs_.setSelection=function(a){var b=this.m,c=this.vc.setSelection(a);if(this.container){a=b.selectedNodeClass||"google-visualization-orgchart-nodesel";for(var d=gvjs_dr(c.zE),e=0;e<d.length;e++){var f=d[e],g=0<=f?this.yh.ww[f]||null:null;g&&(f=g.g4)&&(gvjs_9B(f,a),b.color&&(f.style.background=b.color),g=g.style)&&(f.style.cssText=g)}c=gvjs_dr(c.wB);for(e=0;e<c.length;e++)if(f=c[e],g=0<=f?this.yh.ww[f]||null:null)if(f=g.g4)if(gvjs_7B(f,a),b.selectionColor&&(f.style.background=b.selectionColor),d=
g.Bxa)f.style.cssText=d}};gvjs_.yZ=function(a){a=gvjs_fr(this.vc,a)?null:[{row:a}];this.setSelection(a);gvjs_T(this,gvjs_J,{})};gvjs_.AZ=function(a){gvjs_T(this,gvjs_Kx,{row:a})};gvjs_.zZ=function(a){gvjs_T(this,gvjs_Jx,{row:a})};gvjs_.Tqa=function(a){var b=this.yh.ww[a]||null;this.collapse(a,!(b&&b.collapsed))};gvjs_.Apa=function(){var a=this.yh.find(function(a){return a.collapsed});return gvjs_r(a,function(a){return a.row})};
gvjs_.zpa=function(a){a=this.yh.ww[a]||null;if(!a)return[];a=a.hf();for(var b=[],c=0;c<a.length;c++)b.push(a[c].row);return b};gvjs_.collapse=function(a,b){var c=this.yh.ww[a]||null;c&&c.hf()&&0!=c.hf().length&&(b&&!c.collapsed||!b&&c.collapsed)&&(c.collapsed=b,this.H.uc(this.container),this.BE(this.yh,this.m),gvjs_T(this,gvjs_I,{}),gvjs_T(this,"collapse",{collapsed:b,row:a}))};gvjs_k(gvjs_Zk,gvjs_CW,void 0);gvjs_CW.prototype.draw=gvjs_CW.prototype.draw;gvjs_CW.prototype.getSelection=gvjs_CW.prototype.getSelection;gvjs_CW.prototype.setSelection=gvjs_CW.prototype.setSelection;gvjs_CW.prototype.getChildrenIndexes=gvjs_CW.prototype.zpa;gvjs_CW.prototype.getCollapsedNodes=gvjs_CW.prototype.Apa;gvjs_CW.prototype.collapse=gvjs_CW.prototype.collapse;
